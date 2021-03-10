using Aliyun.OSS;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Aggregate.Media.Common;
using TravelFriend.Aggregate.Media.Models;
using TravelFriend.Common;
using TravelFriend.Common.Http;
using TravelFriend.UserService.Api.Protos;

namespace TravelFriend.Aggregate.Media.Controllers
{
    [ApiController]
    [Route("api/media")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DownloadController : ControllerBase
    {

        [HttpPost("personal/avatar/get")]
        public ActionResult GetPersonalAvatar([FromBody] GetPersonalAvatarReuqest getPersonalAvatar)
        {
            var objectName = $"Avatar/{getPersonalAvatar.Email}.png";
            var result = OssUtil.Download(objectName);
            if (result == null)
            {
                return Ok(new HttpResponse()
                {
                    Code = 201,
                    Message = "Get avatar failed"
                });
            }

            return result;
        }
    }
}
