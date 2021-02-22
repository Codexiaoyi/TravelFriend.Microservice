using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Identity.HttpDto;

namespace TravelFriend.Identity.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {

        }

        [HttpPost("register")]
        public Task<string> Register([FromBody] RegisterRequestDto requestDto)
        {
            return Task.FromResult(Guid.NewGuid() + requestDto.Email);
        }
    }
}
