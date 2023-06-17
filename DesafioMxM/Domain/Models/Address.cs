using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioMxM.Domain.Models;

public class Address:Entity
{
    public string PostalCode { get; set; }
    public string State { get; set; }

    public string City { get; set; }

    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string AddressNumber { get; set; } = "S/N";

    public string Complement { get; set; } = "S/N";

    [ForeignKey("User")]
    public long UserId { get; set; }
    //public virtual User User { get; set; }
}

