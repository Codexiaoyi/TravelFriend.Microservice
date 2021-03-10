using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common.Http;

namespace TravelFriend.Aggregate.Media.Models
{
    public class DownloadResponse : HttpResponse
    {
        /// <summary>
        /// 返回的文件
        /// </summary>
        public FileStreamResult File { get; set; }
    }
}
