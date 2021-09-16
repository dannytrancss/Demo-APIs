using AutoMapper;
using Demo.Application.Parameters;
using Demo.Application.Parameters.Agent;
using Demo.Application.Queries.Agent;
using Demo.Application.ViewModels.Agent;
using Demo.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Application.Handlers.Agent
{
    public class GetAllAgentsHandler : IRequestHandler<GetAllAgentsQuery, PagedResponse<IEnumerable<AgentViewModel>>>
    {
        private readonly IAgentRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAgentsHandler(IAgentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AgentViewModel>>> Handle(GetAllAgentsQuery request, CancellationToken cancellationToken)
        {
            var totalRecords = 0L;
            try
            {
                var validFilter = _mapper.Map<GetAllAgentsParameter>(request);
                var agentList = await _repository.GetAllAgentsAsync(request.PageNumber, request.PageSize);
                var agentViewModel = _mapper.Map<IEnumerable<AgentViewModel>>(agentList);
                totalRecords = await _repository.GetToalRecordsAsync();
                return new PagedResponse<IEnumerable<AgentViewModel>>(agentViewModel, validFilter.PageNumber, validFilter.PageSize, totalRecords);
            }
            catch (Exception ex)
            {
                return new PagedResponse<IEnumerable<AgentViewModel>>(null, request.PageNumber, request.PageSize, totalRecords, false, ex.Message);
            }
        }
    }

}