using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoPlanning.Api.CQRS.Queries.Request;
using ToDoPlanning.Api.CQRS.Queries.Response;

namespace ToDoPlanning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeveloperController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDeveloperPlan()
        {
            //GetDeveloperPlanQueryRequest getListDeveloperQuery = new GetDeveloperPlanQueryRequest()
            //{
            //    ProviderId = providerId
            //};

            GetDeveloperPlanQueryRequest getListDeveloperQuery = new GetDeveloperPlanQueryRequest();
           

            List<GetDeveloperPlanQueryResponse> response = await _mediator.Send(getListDeveloperQuery);
            return Ok(response);
        }
    }
}
