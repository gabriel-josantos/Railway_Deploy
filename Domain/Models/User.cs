using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioMxM.Domain.Models;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(LegalId), IsUnique = true)]
[Index(nameof(PhoneNumber), IsUnique = true)]
public class User : Entity
{
    [Required]
    public string Type { get; set; }
    [Required]
    public string LegalId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public virtual Address Address { get; set; }

}

