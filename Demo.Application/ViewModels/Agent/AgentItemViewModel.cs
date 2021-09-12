using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.ViewModels.Agent
{
    public class AgentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalProjectsDelivered { get; set; }
        public int Reviews { get; set; }
        public DateTimeOffset JoinedDate { get; set; }
    }
}
