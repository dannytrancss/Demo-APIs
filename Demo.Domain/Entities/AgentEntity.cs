using System;

namespace Demo.Domain.Entities
{
    public class AgentEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalProjectsDelivered { get; set; }
        public int Reviews { get; set; }
        public DateTimeOffset JoinedDate { get; set; }
    }
}