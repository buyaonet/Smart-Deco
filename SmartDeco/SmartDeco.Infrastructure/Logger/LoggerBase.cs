#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：LoggerBase
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 21:53:59
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System;
using System.IO;

namespace SmartDeco.Infrastructure.Logger
{
    public abstract class LoggerBase : ILogger
    {
        /// <summary>
        /// 日志 存放地址
        /// </summary>
        protected static string FilePath { get; set; }
        public LoggerBase()
        {
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogDir");
        }

        /// <summary>
        /// 占位符
        /// </summary>
        protected const int LeftTag = 7;

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message"></param>
        protected abstract void WriteLog(string message);

        /// <summary>
        /// 设置二级目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ILogger SetPath(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogDir", path);
            }
            return this;
        }
        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="message"></param>
        public virtual void Logger_Info(string message)
        {
            message = "[Info]".PadLeft(LeftTag) + " " + message;
            WriteLog(message);
        }

        public virtual void Logger_Error(Exception ex)
        {
            string message = "[Error]".PadLeft(LeftTag) + " " + ex.Message;
            WriteLog(message);
        }

        public virtual void Logger_Debug(string message)
        {
            message = "[Debug]".PadLeft(LeftTag) + " " + message;
            WriteLog(message);
        }

        public virtual void Logger_Fatal(string message)
        {
            message = "[Fatal]".PadLeft(LeftTag) + " " + message;
            WriteLog(message);
        }

        public virtual void Logger_Warn(string message)
        {
            message = "[Warn]".PadLeft(LeftTag) + " " + message;
            WriteLog(message); ;
        }
        /// <summary>
        /// 某一代码段出现异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="action"></param>

        public virtual void Logger_Exception(string message, Action action)
        {
            try { action(); }
            catch (Exception ex)
            {
                WriteLog("Logger_Exception:" + message + "代码段出现异常,信息为" + ex.Message);
            }
        }
    }
}
