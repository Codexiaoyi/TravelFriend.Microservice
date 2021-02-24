using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TravelFriend.Common
{
    public class ValidationRules
    {
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
            Match m = RegEmail.Match(email);
            return m.Success;
        }
    }
}
