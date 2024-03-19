using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Core.Domain.Entity;
using Mc2.CrudTest.Core.Domain.Exceptions;
using MediatR;

namespace Mc2.CrudTest.Core.Application.PersonHandlers.Command;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly IContext _context;

    public DeleteCustomerHandler(IContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<Customer>()
            .FindAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException();
        _context.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

public class DeleteCustomerCommand : IRequest
{
    public int Id { get; set; }
}
