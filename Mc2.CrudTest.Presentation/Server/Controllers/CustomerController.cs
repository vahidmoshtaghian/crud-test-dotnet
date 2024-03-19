using Mc2.CrudTest.Core.Application.PersonHandlers.Command;
using Mc2.CrudTest.Presentation.Server.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

public class CustomerController : ApplicationControllerBase
{
    [HttpPost]
    public async Task<int> Add([FromBody] AddCustomerCommand command)
    {
        return await Mediator.Send(command);
    }
}