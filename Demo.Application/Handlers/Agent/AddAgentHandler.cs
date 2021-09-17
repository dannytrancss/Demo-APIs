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
    public class AddAgentHandler : IRequestHandler<AddAgentCommand, Response<AgentViewModel>>
    {
        private readonly IAgentRepository _repository;
        private readonly IMapper _mapper;

        public AddAgentHandler(IAgentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        /// <summary>
        /// To process for adding an agent request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<AgentViewModel>> Handle(AddAgentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _mapper.Map<AgentEntity>(request);
                await _repository.AddAgentAsync(item);

                return new Response<AgentViewModel>(_mapper.Map<AgentViewModel>(item));
            }
           catch(Exception ex)
            {
                return new Response<AgentViewModel>(ex.Message);
            }
        }
    }
}