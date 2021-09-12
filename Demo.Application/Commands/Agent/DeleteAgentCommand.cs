using System;
using System.ComponentModel.DataAnnotations;
using Demo.Application.Parameters;
using Demo.Application.ViewModels.Agent;
using MediatR;

namespace Demo.Application.Commands.Agent
{
    public class DeleteAgentCommand : IRequest<Response<AgentViewModel>>
    {
        [Required]
        public Guid Id { get; set; }
    }
}