#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：TimeHelper
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 20:48:38
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System;

namespace SmartDeco.Infrastructure
{
    /// <summary>
    /// 时间操作
    /// </summary>
    public class TimeHelper
    {
        /// <summary>
        /// 转换为时间戳
        /// </summary>
        /// <returns></returns>
        public static long ToTimeStamp(DateTime time)
        {
#pragma warning disable CS0618 // 类型或成员已过时
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
#pragma warning restore CS0618 // 类型或成员已过时
            long t = (time.Ticks - startTime.Ticks) / 10000;     
            return t;
        }
        /// <summary>
        /// 时间戳转为时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(long timeStamp)
        {
#pragma warning disable CS0618 // 类型或成员已过时
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
#pragma warning restore CS0618 // 类型或成员已过时
            long lTime = long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
    }
}
