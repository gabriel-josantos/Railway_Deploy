using DesafioMxM.Domain;
using DesafioMxM.Domain.Models;
using DesafioMxM.Repositories.Interfaces;

namespace DesafioMxM.Repositories;

public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    public AddressRepository(ApplicationContext context) : base(context)
    {

    }

}

