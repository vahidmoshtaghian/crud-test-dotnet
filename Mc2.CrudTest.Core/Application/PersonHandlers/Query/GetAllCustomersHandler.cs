using Mc2.CrudTest.Core.Domain.Contract;
using Mc2.CrudTest.Core.Domain.Dto.PersonModels;
using Mc2.CrudTest.Core.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Core.Application.PersonHandlers.Query;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<GetAllCustomersQueryResponse>>
{
    private readonly IContext _context;

    public GetAllCustomersHandler(IContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.Set<Customer>()
            .OrderBy(p => p.FirstName)
            .ThenBy(p => p.LastName)
            .ToListAsync(cancellationToken);
        var result = entities.Select(p => new GetAllCustomersQueryResponse(p));

        return result;
    }
}

#nullable disable

public class GetAllCustomersQuery : IRequest<IEnumerable<GetAllCustomersQueryResponse>>
{

}

public class GetAllCustomersQueryResponse : CustomerDto
{
    public GetAllCustomersQueryResponse(Customer entity) : base(entity)
    {

    }
}
