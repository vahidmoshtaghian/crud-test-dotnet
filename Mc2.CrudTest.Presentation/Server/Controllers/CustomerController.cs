using Mc2.CrudTest.Presentation.Server.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    public class CustomerController : ApplicationControllerBase
    {
        [HttpGet]
        public async Task Get()
        {
            //var result = await Mediator.Send(new AddCustomerCommand());
            throw new NotImplementedException();
        }
    }
}