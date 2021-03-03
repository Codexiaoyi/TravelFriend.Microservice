using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common.Http;
using TravelFriend.UserService.Api.Application.Commands;

namespace TravelFriend.UserService.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/user/team")]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateNewTeam([FromBody] CreateTeamCommand cteateTeam)
        {
            var result = await _mediator.Send(cteateTeam);
            if (result)
                return Ok(new HttpResponse { Code = 200 });
            return Ok(new HttpResponse { Code = 201, Message = "Create Failed" });
        }
    }
}
