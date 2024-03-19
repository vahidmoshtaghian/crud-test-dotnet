using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Core.Domain.Entity;
using MediatR;

namespace Mc2.CrudTest.Core.Application.PersonHandlers.Command;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, int>
{
    private readonly IContext _context;

    public AddCustomerHandler(IContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = request.MapToDomain();
        _context.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

#nullable disable

public record AddCustomerCommand(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    long PhoneNumber,
    string Email,
    string BankAccountNumber) : IRequest<int>
{
    public Customer MapToDomain() => new()
    {
        FirstName = FirstName,
        LastName = LastName,
        DateOfBirth = DateOfBirth,
        PhoneNumber = PhoneNumber,
        Email = Email,
        BankAccountNumber = BankAccountNumber
    };
}

