#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：ValidateHelper
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 20:48:59
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System.Text.RegularExpressions;

namespace SmartDeco.Infrastructure
{
    /// <summary>
    /// 验证用户账号
    /// </summary>
    public class ValidateHelper
    {
        /// <summary>
        /// 判断是否是邮箱
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsEmail(string message)
        {
            string pattern = @"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$";
            return Regex.IsMatch(message, pattern, RegexOptions.IgnorePatternWhitespace);
        }
        /// <summary>
        /// 判断是否是手机号码
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool IsPhone(string message)
        {
            string pattern = @"^((1[3,5,8][0-9])|(14[5,7])|(17[0,6,7,8])|(19[7]))\\d{8}$";
            return Regex.IsMatch(message, pattern, RegexOptions.IgnorePatternWhitespace);
        }
    }
}
