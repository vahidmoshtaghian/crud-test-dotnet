using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Core.Domain.Dto.PersonModels;
using MediatR;

namespace Mc2.CrudTest.Core.Application.PersonHandlers.Command;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, IEnumerable<AddCustomerCommandResponse>>
{
    private readonly IContext _context;

    public AddCustomerHandler(IContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<AddCustomerCommandResponse>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

#nullable disable

public class AddCustomerCommand : IRequest<IEnumerable<AddCustomerCommandResponse>>
{

}

public class AddCustomerCommandResponse : CustomerDto
{
    public new int Id { get; set; }
}
