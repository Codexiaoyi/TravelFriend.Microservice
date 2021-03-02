using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TravelFriend.Aggregate.Upload.HttpDto;
using TravelFriend.Common.Http;

namespace TravelFriend.Aggregate.Upload.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/upload")]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        private readonly IConfiguration _configuration;

        public UploadController(ILogger<UploadController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("token/get")]
        public ActionResult GetOssToken()
        {
            string accessKey = _configuration.GetValue<string>("AccessKey");//AK
            string secretKey = _configuration.GetValue<string>("SecretKey");//SK
            string bucket = _configuration.GetValue<string>("Bucket");//存储空间名称

            //鉴权对象
            Mac mac = new Mac(accessKey, secretKey);
            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = bucket;
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new OssTokenResponseDto()
                {
                    Code = 200,
                    Token = token
                });
            }

            return Ok(new HttpResponse()
            {
                Code = 201,
                Message = "Get token failed"
            });
        }
    }
}