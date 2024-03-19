#nullable disable
namespace Mc2.CrudTest.Core.Domain.Dto.PersonModels;

public class CustomerDto
{
    protected int Id { get; set; }

    public string FirsName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public long PhoneNumber { get; set; }

    public string Email { get; set; }

    public string BankAccountNumber { get; set; }

    public void SetId(int id) => Id = id;
}
