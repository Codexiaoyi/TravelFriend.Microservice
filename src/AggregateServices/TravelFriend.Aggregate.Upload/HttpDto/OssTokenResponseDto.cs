using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common.Http;

namespace TravelFriend.Aggregate.Upload.HttpDto
{
    public class OssTokenResponseDto : HttpResponse
    {
        public string Token { get; set; }
    }
}
