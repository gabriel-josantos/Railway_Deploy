using AutoMapper;
using DesafioMxM.Domain.Dtos;
using DesafioMxM.Domain.Models;
using DesafioMxM.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMxM.Controllers;

[ApiController]
[Route("/users")]

public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IAddressRepository addressRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _addressRepository = addressRepository;
        _mapper = mapper;
    }


    // <summary>
    //Cria uma nova conta para o usuário.
    //</summary>
    //<param name="signupDto">Dados do formulário de cadastro.</param>
    //<returns>Um objeto com a mensagem "successful"</returns>
    //<response code="201">Retorna a resposta com sucesso.</response>
    //<response code="400">Retorna a resposta com erro.</response>
    //<returns></returns>
    [HttpPost]

    public async Task CreateUser([FromBody] SignupDto signupDto)
    {

        User newUser = _mapper.Map<User>(signupDto);

        await _userRepository.Create(newUser);

        Address newAddress = _mapper.Map<Address>(signupDto, options =>
        {
            options.AfterMap((src, dest) => dest.UserId = newUser.Id);
        });
 
        await _addressRepository.Create(newAddress);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAll();
        var userDtos = _mapper.ProjectTo<UserDto>(users.AsQueryable()).ToList();
        return Ok(userDtos);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            
            User user = await _userRepository.GetById(id);
            if (user == null) throw new Exception("Usuario nao encontrado");
            UserDto userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
       
    }

}
