#nullable disable
using Mc2.CrudTest.Core.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Core.Domain.Entity;

[Table("Customers", Schema = "Person")]
public class Customer : EntityBase
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [Required, MaxLength(100)]
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Required, MaxLength(20)]
    public long PhoneNumber { get; set; }

    [Required, MaxLength(100)]
    public string Email { get; set; }

    [Required, MaxLength(100)]
    public string BankAccountNumber { get; set; }
}
