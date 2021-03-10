using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class UploadController : ControllerBase
    {
        private readonly UserProvider.UserProviderClient _userProviderClient;

        public UploadController(UserProvider.UserProviderClient userProviderClient)
        {
            _userProviderClient = userProviderClient;
        }

        [HttpPost("personal/avatar/update")]
        public async Task<ActionResult> UpdatePersonalAvatar([FromForm] UpdatePersonalAvatarRequest request)
        {
            var endpoint = AppSettings.GetJsonString("OssEndpoint");
            var bucketName = AppSettings.GetJsonString("BucketName");
            var objectName = $"Avatar/{request.Email}.png";

            //上传到oss后保存头像地址
            var addAvatar = await _userProviderClient.UpdatePersonalAvatarAsync(new UpdatePersonalAvatarCommand() { Email = request.Email, Avatar = $"{endpoint}/{bucketName}/{objectName}" });
            if (!addAvatar.Result)
            {
                return Ok(new HttpResponse()
                {
                    Code = 201,
                    Message = "Upload failed"
                });
            }

            var result = await OssUtil.UploadAsync(request.Avatar, objectName);
            if (!result)
            {
                return Ok(new HttpResponse()
                {
                    Code = 201,
                    Message = "Upload failed"
                });
            }
            return Ok(new HttpResponse()
            {
                Code = 200,
                Message = "Upload succeeded"
            });
        }
    }
}
