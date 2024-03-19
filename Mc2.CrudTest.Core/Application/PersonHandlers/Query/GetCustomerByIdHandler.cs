using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Core.Domain.Dto.PersonModels;
using Mc2.CrudTest.Core.Domain.Entity;
using Mc2.CrudTest.Core.Domain.Exceptions;
using MediatR;

namespace Mc2.CrudTest.Core.Application.PersonHandlers.Query;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResponse>
{
    private readonly IContext _context;

    public GetCustomerByIdHandler(IContext context)
    {
        _context = context;
    }

    public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<Customer>()
            .FindAsync(request.Id)
            ?? throw new NotFoundException();

        return new(entity);
    }
}

public class GetCustomerByIdQuery : IRequest<GetCustomerByIdQueryResponse>
{
    public int Id { get; set; }
}

public class GetCustomerByIdQueryResponse : CustomerDto
{
    public GetCustomerByIdQueryResponse(Customer entity) : base(entity)
    {

    }
}