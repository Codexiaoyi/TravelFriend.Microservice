using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common;
using TravelFriend.Common.Http;
using TravelFriend.EventBus.IntegrationEvents;
using TravelFriend.Identity.HttpDto;
using TravelFriend.Identity.Infrastructure;

namespace TravelFriend.Identity.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICapPublisher _capPublisher;

        public AccountController(IAccountRepository accountRepository, ICapPublisher capPublisher)
        {
            _accountRepository = accountRepository;
            _capPublisher = capPublisher;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] AccountRequestDto requestDto)
        {
            if (!ValidationRules.IsEmail(requestDto.Email))
            {
                return Ok(new HttpResponse()
                {
                    Code = 203,
                    Message = "Email Rules Error"
                });
            }

            var account = await _accountRepository.QueryAccountAsync(requestDto.Email);
            if (account != null)
            {
                return Ok(new HttpResponse()
                {
                    Code = 202,
                    Message = "Email Existed"
                });
            }

            var result = await _accountRepository.AddAccountAsync(new Account()
            {
                UserEmail = requestDto.Email,
                Password = requestDto.Password
            });
            if (result)
            {
                //User服务增加一条用户信息条目
                await _capPublisher.PublishAsync("UserRegisterSucceeded", new UserRegisterSucceededIntegrationEvent(requestDto.Email));

                return Ok(new HttpResponse()
                {
                    Code = 200,
                    Message = "Register Succeeded"
                });
            }

            return Ok(new HttpResponse()
            {
                Code = 201,
                Message = "Register Failed"
            });
        }

        [HttpPost("login")]
        public Task<string> Login([FromBody] AccountRequestDto requestDto)
        {
            return Task.FromResult(Guid.NewGuid() + requestDto.Email);
        }
    }
}
