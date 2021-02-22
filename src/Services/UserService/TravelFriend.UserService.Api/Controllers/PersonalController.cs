﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common.Http;
using TravelFriend.UserService.Api.Application.Commands;

namespace TravelFriend.UserService.Api.Controllers
{
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
        public async Task<HttpResponse> UpdatePersonalInfo([FromBody] UpdatePersonalCommand updatePersonal)
        {
            var result = await _mediator.Send(updatePersonal);
            if (result)
                return new HttpResponse { Code = 200 };
            return new HttpResponse { Code = 201, Message = "更新失败" };
        }
    }
}