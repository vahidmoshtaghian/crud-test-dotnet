#nullable disable
using Mc2.CrudTest.Core.Domain.Entity;

namespace Mc2.CrudTest.Core.Domain.Dto.PersonModels;

public class CustomerDto
{
    public CustomerDto()
    {

    }

    public CustomerDto(Customer entity)
    {
        Id = entity.Id;
        FirsName = entity.FirstName;
        LastName = entity.LastName;
        DateOfBirth = entity.DateOfBirth;
        PhoneNumber = entity.PhoneNumber;
        Email = entity.Email;
        BankAccountNumber = entity.BankAccountNumber;
    }

    protected int Id { get; set; }

    public string FirsName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public long PhoneNumber { get; set; }

    public string Email { get; set; }

    public string BankAccountNumber { get; set; }

    public void SetId(int id) => Id = id;
}
