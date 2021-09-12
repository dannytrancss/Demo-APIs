using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Domain.Interfaces
{
    public interface IAgentRepository
    {
        Task<AgentEntity> GetAgentByIdAsync(Guid id);
        Task<IReadOnlyCollection<AgentEntity>> GetAllAgentsAsync(int pageNumber, int pageSize);
        Task AddAgentAsync(AgentEntity agent);
        Task UpdateAgentAsync(AgentEntity agent);
        Task<Guid?> DeleteAgentAsync(Guid id);
    }
}