using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Core.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        await _context.Set<Customer>().ToListAsync();
        throw new NotImplementedException();
    }
}

#nullable disable

public record AddCustomerCommand(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    long PhoneNumber,
    string Email,
    string BankAccountNumber) : IRequest<int>;

