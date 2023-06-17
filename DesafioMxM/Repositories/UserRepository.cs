using DesafioMxM.Domain;
using DesafioMxM.Domain.Models;
using DesafioMxM.Repositories.Interfaces;

namespace DesafioMxM.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationContext context) : base(context)
    {

    }

}

