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
using TravelFriend.UserService.Api.Application.Queries;

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

        [HttpPost("info/update")]
        public async Task<ActionResult> UpdateTeamInfo([FromBody] UpdateTeamInfoCommand updateTeamInfo)
        {
            var result = await _mediator.Send(updateTeamInfo);
            if (result)
                return Ok(new HttpResponse { Code = 200 });
            return Ok(new HttpResponse { Code = 201, Message = "Update Failed" });
        }

        [HttpPost("info/get")]
        public async Task<ActionResult> GetTeamInfo([FromBody] TeamInfoQuery teamInfo)
        {
            var result = await _mediator.Send(teamInfo);
            if (result == null)
                return Ok(new HttpResponse { Code = 201, Message = "Team not exist" });

            return Ok(new TeamInfoResponseDto
            {
                Code = 200,
                Team = result
            });
        }

        [HttpPost("member/get")]
        public async Task<ActionResult> GetTeamMembers([FromBody] TeamMembersQuery membersQuery)
        {
            var result = await _mediator.Send(membersQuery);
            if (result == null)
                return Ok(new HttpResponse { Code = 201, Message = "Team not exist" });

            return Ok(new TeamMemberResponseDto
            {
                Code = 200,
                Members = result
            });
        }
    }
}
