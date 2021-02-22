using System;
using System.Collections.Generic;
using System.Text;

namespace TravelFriend.Common.Http
{
    public class HttpResponse
    {
        /// <summary>
        /// 返回错误码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
