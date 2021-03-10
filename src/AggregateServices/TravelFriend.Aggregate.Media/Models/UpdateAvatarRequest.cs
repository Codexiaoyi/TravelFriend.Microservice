using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.Aggregate.Media.Models
{
    public class UpdatePersonalAvatarRequest
    {
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 头像文件
        /// </summary>
        public IFormFile Avatar { get; set; }
    }

    public class GetPersonalAvatarReuqest
    {
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
    }
}
