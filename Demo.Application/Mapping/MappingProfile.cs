using AutoMapper;
using Demo.Application.Commands.Agent;
using Demo.Application.Parameters.Agent;
using Demo.Application.Queries.Agent;
using Demo.Application.ViewModels.Agent;
using Demo.Domain.Entities;

namespace Demo.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create agent item
            CreateMap<AddAgentCommand, AgentEntity>().ReverseMap();

            //Update agent item
            CreateMap<UpdateAgentCommand, AgentEntity>().ReverseMap();

            // View agent items
            CreateMap<AgentEntity, AgentViewModel>().ReverseMap();
            CreateMap<GetAllAgentsQuery, GetAllAgentsParameter>();
        }
    }
}