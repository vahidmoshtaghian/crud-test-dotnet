using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class ApplicationControllerBase : ControllerBase
{
    public IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
}
