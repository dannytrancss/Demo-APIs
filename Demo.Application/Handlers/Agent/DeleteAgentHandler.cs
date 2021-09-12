using Demo.Application.Commands.Agent;
using Demo.Application.Parameters;
using Demo.Application.ViewModels.Agent;
using Demo.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Application.Handlers.Agent
{
    public class DeleteAgentHandler : IRequestHandler<DeleteAgentCommand, Response<AgentViewModel>>
    {
        private readonly IAgentRepository _repository;

        public DeleteAgentHandler(IAgentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<AgentViewModel>> Handle(DeleteAgentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = _repository.GetAgentByIdAsync(request.Id);
                if (response == null || response.Result == null)
                    return new Response<AgentViewModel>("Agent Not Found");

                await _repository.DeleteAgentAsync(request.Id);

                return new Response<AgentViewModel>(request.Id.ToString(), true);
            }
            catch (Exception ex)
            {
                return new Response<AgentViewModel>(ex.Message);
            }
        }
    }
}