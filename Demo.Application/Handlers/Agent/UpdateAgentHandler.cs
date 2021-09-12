using AutoMapper;
using Demo.Application.Commands.Agent;
using Demo.Application.Parameters;
using Demo.Application.ViewModels.Agent;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Application.Handlers.Agent
{
    public class UpdateAgentHandler : IRequestHandler<UpdateAgentCommand, Response<AgentViewModel>>
    {
        private readonly IAgentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAgentHandler(IAgentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<AgentViewModel>> Handle(UpdateAgentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = _repository.GetAgentByIdAsync(request.Id);
                if (response == null || response.Result == null)
                    return new Response<AgentViewModel>("Agent Not Found");

                var item = _mapper.Map<AgentEntity>(request);
                await _repository.UpdateAgentAsync(item);

                return new Response<AgentViewModel>(_mapper.Map<AgentViewModel>(item));
            }
            catch (Exception ex)
            {
                return new Response<AgentViewModel>(ex.Message);
            }
        }
    }
}