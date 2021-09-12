using Demo.Application.Parameters;
using Demo.Application.ViewModels.Agent;
using MediatR;
using System.Collections.Generic;

namespace Demo.Application.Queries.Agent
{
    public class GetAllAgentsQuery : IRequest<PagedResponse<IEnumerable<AgentViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}