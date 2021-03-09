using Aliyun.OSS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Common;

namespace TravelFriend.Aggregate.Media.Common
{
    public class OssUtil
    {
        /// <summary>
        /// 上传文件到oss
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="objectName">文件目录及名称</param>
        /// <returns></returns>
        public static async Task<bool> UploadAsync(IFormFile file, string objectName)
        {
            // 创建OssClient实例。
            var client = new OssClient(AppSettings.GetJsonString("OssEndpoint"), AppSettings.GetJsonString("AccessKey"), AppSettings.GetJsonString("SecurityKey"));
            try
            {
                using (MemoryStream requestContent = new MemoryStream())
                {
                    requestContent.Position = 0;
                    await file.CopyToAsync(requestContent);
                    requestContent.Position = 0;
                    // 上传文件。
                    client.PutObject(AppSettings.GetJsonString("BucketName"), objectName, requestContent);
                    Console.WriteLine("Put object succeeded");
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                Console.WriteLine("Put object failed, {0}", ex.Message);
            }
        }
    }
}
