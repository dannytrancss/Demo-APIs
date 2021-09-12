using Demo.Application.Parameters;
using Demo.Application.ViewModels.Agent;
using MediatR;
using System;

namespace Demo.Application.Queries.Agent
{

    public class GetAgentQuery : IRequest<Response<AgentViewModel>>
    {
        public Guid Id { get; set; }
    }
}