using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TravelFriend.Identity.Authorization
{
    public class JwtHelper
    {
        public static IConfiguration _configuration { get; set; }

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 根据用户邮箱获取Token
        /// </summary>
        /// <param name="useremail"></param>
        /// <returns></returns>
        public static string GetToken(string useremail)
        {
            var claims = new List<Claim>()
            {
                new Claim("Name", useremail),
                new Claim("Audience","travelfriend"),
                new Claim("Issuer","travelfriend")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "travelfriend",
                audience: "travelfriend",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
