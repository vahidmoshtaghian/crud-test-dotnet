using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Core.Domain.Dto.PersonModels;
using Mc2.CrudTest.Core.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Core.Application.PersonHandlers.Command;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, AddCustomerCommandResponse>
{
    private readonly IContext _context;

    public AddCustomerHandler(IContext context)
    {
        _context = context;
    }

    public async Task<AddCustomerCommandResponse> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        await _context.Set<Customer>().ToListAsync();
        throw new NotImplementedException();
    }
}

#nullable disable

public class AddCustomerCommand : IRequest<AddCustomerCommandResponse>
{

}

public class AddCustomerCommandResponse : CustomerDto
{
    public new int Id { get; set; }
}
