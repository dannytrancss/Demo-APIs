using AutoMapper;
using Demo.Application.Parameters;
using Demo.Application.Queries.Agent;
using Demo.Application.ViewModels.Agent;
using Demo.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Application.Handlers.Agent
{
    public class GetAgentHandler : IRequestHandler<GetAgentQuery, Response<AgentViewModel>>
    {
        private readonly IAgentRepository _repository;
        private readonly IMapper _mapper;

        public GetAgentHandler(IAgentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<AgentViewModel>> Handle(GetAgentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var agent = await _repository.GetAgentByIdAsync(request.Id);
                if (agent == null)
                    return new Response<AgentViewModel>("Item Not Found");

                return new Response<AgentViewModel>(_mapper.Map<AgentViewModel>(agent));
            }
            catch(Exception ex)
            {
                return new Response<AgentViewModel>(ex.Message);
            }
        }
    }
}