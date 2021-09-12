using AutoMapper;
using Demo.Application.Handlers.Agent;
using Demo.Application.Mapping;
using Demo.Domain.Interfaces;
using Demo.Infrastructture.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Demo.Application
{
    public static class ServiceInjection
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(serviceProvider =>
                {
                    const string connectionString = "mongodb://localhost:27017";
                    var mongoClient = new MongoClient(connectionString);
                    return mongoClient.GetDatabase("Agent");
                });

            services.AddSingleton<IAgentRepository, AgentRepository>();

            services.AddScoped<IMediator, Mediator>();
            services.AddMediatR(typeof(AddAgentHandler).Assembly);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}