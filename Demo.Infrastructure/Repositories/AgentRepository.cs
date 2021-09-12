using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;

namespace Demo.Infrastructture.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private const string CollectionName = "agents";
        private readonly IMongoCollection<AgentEntity> _dbCollection;
        private readonly FilterDefinitionBuilder<AgentEntity> _filterBuilder = Builders<AgentEntity>.Filter;

        public AgentRepository(IMongoDatabase database)
        {
            _dbCollection = database.GetCollection<AgentEntity>(CollectionName);
        }

        public async Task<AgentEntity> GetAgentByIdAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(agent => agent.Id, id);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<AgentEntity>> GetAllAgentsAsync(int pageNumber, int pageSize)
        {
            return await _dbCollection.Find(_filterBuilder.Empty)
                    .Skip((pageNumber - 1) * pageSize)
                    .Limit(pageSize).ToListAsync();
        }

        public async Task AddAgentAsync(AgentEntity agent)
        {
            if (agent == null)
            {
                throw new ArgumentNullException(nameof(agent));
            }

            await _dbCollection.InsertOneAsync(agent);
        }

        public async Task UpdateAgentAsync(AgentEntity agent)
        {
            if (agent == null)
            {
                throw new ArgumentNullException(nameof(agent));
            }

            var filter = _filterBuilder.Eq(agent => agent.Id, agent.Id);

            await _dbCollection.ReplaceOneAsync(filter, agent);
        }

        public async Task<Guid?> DeleteAgentAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(agent => agent.Id, id);
            var result = await _dbCollection.DeleteOneAsync(filter);

            if (result.DeletedCount != 0) return id;

            return null;
        }
    }
}