using Demo.Application.Parameters;
using Demo.Application.ViewModels.Agent;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Application.Commands.Agent
{
    public class UpdateAgentCommand : IRequest<Response<AgentViewModel>>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(0, int.MaxValue)]
        public int TotalProjectsDelivered { get; set; }
        [Range(0, int.MaxValue)]
        public int Reviews { get; set; }
        [Required]
        public DateTimeOffset JoinedDate { get; set; }
    }
}