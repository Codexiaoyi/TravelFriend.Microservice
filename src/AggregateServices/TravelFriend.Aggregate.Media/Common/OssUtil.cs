using Aliyun.OSS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="objectName">文件目录及名称</param>
        /// <returns></returns>
        public static FileStreamResult Download(string objectName)
        {
            var bucketName = AppSettings.GetJsonString("BucketName");
            // 创建OssClient实例。
            var client = new OssClient(AppSettings.GetJsonString("OssEndpoint"), AppSettings.GetJsonString("AccessKey"), AppSettings.GetJsonString("SecurityKey"));
            try
            {
                // 下载文件到流。OssObject 包含了文件的各种信息，如文件所在的存储空间、文件名、元信息以及一个输入流。
                var obj = client.GetObject(bucketName, objectName);
                return new FileStreamResult(obj.Content, "image/png");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get object failed. {0}", ex.Message);
                return null;
            }
        }
    }
}
