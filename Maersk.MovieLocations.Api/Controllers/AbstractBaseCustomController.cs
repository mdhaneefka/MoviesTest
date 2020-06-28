using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Maersk.MovieLocations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbstractBaseCustomController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}