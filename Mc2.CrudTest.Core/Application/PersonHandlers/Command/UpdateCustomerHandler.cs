using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Core.Domain.Dto.PersonModels;
using Mc2.CrudTest.Core.Domain.Entity;
using Mc2.CrudTest.Core.Domain.Exceptions;
using MediatR;

namespace Mc2.CrudTest.Core.Application.PersonHandlers.Command;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly IContext _context;

    public UpdateCustomerHandler(IContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<Customer>()
            .FindAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException();

        request.MapToDomain(entity);
        _context.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

public class UpdateCustomerCommand : CustomerDto, IRequest
{

}
