using Mc2.CrudTest.Core.Application.PersonHandlers.Command;
using Mc2.CrudTest.Core.Application.PersonHandlers.Query;
using Mc2.CrudTest.Presentation.Server.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

public class CustomerController : ApplicationControllerBase
{
    [HttpPost]
    public Task<int> Add([FromBody] AddCustomerCommand command)
    {
        return Mediator.Send(command);
    }

    [HttpGet]
    public Task<IEnumerable<GetAllCustomersQueryResponse>> GetAll()
    {
        return Mediator.Send(new GetAllCustomersQuery());
    }

    [HttpGet("{id:int}")]
    public async Task<GetCustomerByIdQueryResponse> GetById([FromRoute] int id)
    {
        return await Mediator.Send(new GetCustomerByIdQuery() { Id = id });
    }

    [HttpPut("{id:int}")]
    public async Task Update([FromRoute] int id, [FromBody] UpdateCustomerCommand command)
    {
        command.SetId(id);
        await Mediator.Send(command);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete([FromRoute] int id)
    {
        DeleteCustomerCommand command = new() { Id = id };
        await Mediator.Send(command);
    }
}