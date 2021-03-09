using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelFriend.Common
{
    /// <summary>
    /// 针对appsettings.json
    /// </summary>
    public class AppSettings
    {
        public static IConfiguration Configuration { get; set; }

        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 得到appsettings.json中的字符串
        /// </summary>
        /// <param name="sections">Json对象名，按照顺序传</param>
        /// <returns>得到字符串</returns>
        public static string GetJsonString(params string[] sections)
        {
            var values = string.Empty;
            for (int i = 0; i < sections.Length; i++)
            {
                values += sections[i] + ":";
            }
            return Configuration[values.TrimEnd(':')];//返回得到的字符串
        }
    }
}
