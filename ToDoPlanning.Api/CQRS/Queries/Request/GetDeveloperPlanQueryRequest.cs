using MediatR;
using ToDoPlanning.Api.CQRS.Queries.Response;

namespace ToDoPlanning.Api.CQRS.Queries.Request
{
    public class GetDeveloperPlanQueryRequest : IRequest<List<GetDeveloperPlanQueryResponse>>
    {
    }
}
