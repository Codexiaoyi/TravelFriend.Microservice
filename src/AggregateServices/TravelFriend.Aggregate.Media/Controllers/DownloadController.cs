using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.UserService.Api.Protos;

namespace TravelFriend.Aggregate.Media.Controllers
{
    [ApiController]
    [Route("api/media")]
    public class DownloadController : ControllerBase
    {
        private readonly UserProvider.UserProviderClient _userProviderClient;

        public DownloadController(UserProvider.UserProviderClient userProviderClient)
        {
            _userProviderClient = userProviderClient;
        }

        [HttpPost("personal/avatar/get")]
        public async Task<ActionResult> GetPersonalAvatar()
        {
            var result = await _userProviderClient.UpdatePersonalAvatarAsync(new UpdatePersonalAvatarCommand() { Email = "123@qq.com", Avatar = "aaaaa_avatar" });
            return Ok();
        }
    }
}
