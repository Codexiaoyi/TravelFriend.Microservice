using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    [Route("api/user/personal")]
    public class PersonalController : ControllerBase
    {
        private readonly ILogger<PersonalController> _logger;
        private readonly IMediator _mediator;

        public PersonalController(IMediator mediator, ILogger<PersonalController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdatePersonalInfo([FromBody] UpdatePersonalCommand updatePersonal)
        {
            var result = await _mediator.Send(updatePersonal);
            if (result)
                return Ok(new HttpResponse { Code = 200 });
            return Ok(new HttpResponse { Code = 201, Message = "Update Failed" });
        }

        [HttpPost("get")]
        public async Task<ActionResult> GetPersonalInfo([FromBody] PersonalInfoQuery personalInfo)
        {
            var result = await _mediator.Send(personalInfo);
            if (result == null)
            {
                return Ok(new HttpResponse
                {
                    Code = 201,
                    Message = "User not exist"
                });
            }

            return Ok(new PersonalInfoResponseDto
            {
                Code = 200,
                Personal = result
            });
        }
    }
}
