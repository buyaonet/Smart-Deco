#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：FileLogger
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 21:51:03
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System;
using System.Diagnostics;
using System.IO;

namespace SmartDeco.Infrastructure.Logger
{
    /// <summary>
    /// 普通日志
    /// </summary>
    public class FileLogger : LoggerBase
    {
        /// <summary>
        /// 线程锁
        /// </summary>
        private static object obj = new object();

        /// <summary>
        /// 实现 写日志方法
        /// </summary>
        /// <param name="message"></param>
        protected override void WriteLog(string message)
        {
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogDir");
            }
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            string logPath = Path.Combine(FilePath, DateTime.Now.ToLongDateString() + ".log");

            // 写日志 
            Action<string> action = (filename) =>
            {
                lock (obj)
                {
                    using (StreamWriter sw = new StreamWriter(filename, true))
                    {
                        sw.WriteLine(string.Format("{0}{1}", DateTime.Now.ToString().PadRight(20), message));
                    }
                }
            };


            try
            {
                action(logPath);
            }
            catch (Exception)
            {
                action(Path.Combine(FilePath, DateTime.Now.ToLongDateString() + Process.GetCurrentProcess().Id + ".log"));
            }
        }
    }
}
