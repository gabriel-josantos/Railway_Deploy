using DesafioMxM.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioMxM.Domain.Dtos;

public class UserDto
{
    public string Type { get; set; }
    public string Name { get; set; }

    public string LegalId { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string PostalCode { get; set; }
    public string State { get; set; }

    public string City { get; set; }

    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string AddressNumber { get; set; } = "S/N";

    public string Complement { get; set; } = "S/N";
}

