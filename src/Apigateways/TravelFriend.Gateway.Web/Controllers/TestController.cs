using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace TravelFriend.Gateway.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Abc()
        {
            return Content("GeekTime.Mobile.Gateway");
        }

        [HttpGet]
        public IActionResult ShowRequestUri()
        {
            return Content(Request.GetDisplayUrl());
        }

        [HttpGet("headers")]
        public IActionResult ShowHeaders()
        {
            var sb = new System.Text.StringBuilder();
            foreach (var item in Request.Headers)
            {
                sb.AppendLine($"{item.Key}:{item.Value}");
            }

            return Content(sb.ToString());
        }
    }
}