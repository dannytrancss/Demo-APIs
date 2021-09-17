using Demo.Application.Commands.Agent;
using Demo.Application.Parameters.Agent;
using Demo.Application.Queries.Agent;
using Demo.Application.ViewModels.Agent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.WebApi.Controllers
{
    [ApiController]
    [Route("agents")]
    public class AgentsController : Controller
    {
        private readonly IMediator _mediator;

        public AgentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get agent list with paging
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetAllAgents")]
        public async Task<ActionResult<IEnumerable<AgentViewModel>>> GetAllAgentsAsync([FromQuery] GetAllAgentsParameter filter)
        {
            return Ok(await _mediator.Send(new GetAllAgentsQuery() { PageNumber = filter.PageNumber, PageSize = filter.PageSize }));
        }
        /// <summary>
        /// Get an agent by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAgentById")]
        public async Task<ActionResult<AgentViewModel>> GetAgentByIdAsync(Guid id)
        {
            return Ok(await _mediator.Send(new GetAgentQuery() { Id = id }));
        }
        /// <summary>
        /// Add an agent
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddAgent")]
        public async Task<ActionResult<AgentViewModel>> AddAgentAsync([FromBody] AddAgentCommand command)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(command));
        }
        /// <summary>
        /// update an agent
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateAgent")]
        public async Task<ActionResult<AgentViewModel>> UpdateAgentAsync([FromBody] UpdateAgentCommand command)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            
            return Ok(await _mediator.Send(command));
        }
        /// <summary>
        /// Delete an agent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteAgent")]
        public async Task<ActionResult<Guid?>> DeleteAgent(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteAgentCommand() { Id = id }));
        }
    }
}