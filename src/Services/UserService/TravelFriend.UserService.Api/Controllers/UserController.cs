using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.UserService.Api.Application.Commands;

namespace TravelFriend.UserService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator,ILogger<UserController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<Guid> RegisterUser([FromBody] RegisterUserCommand registerUser)
        {
            //if (!registerUser.IsValid())
            //{

            //}
            return await _mediator.Send(registerUser);
        }
    }
}
