#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：Log4Logger
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 22:13:06
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository;
using System;
using System.IO;

namespace SmartDeco.Infrastructure.Logger
{
    public class Log4Logger : LoggerBase
    {
        /// <summary>
        /// log4net 日志配置
        /// </summary>
        public static string LogConfig = string.Empty;

        /// <summary>
        /// 日志执行对象
        /// </summary>
        public static ILog logImpl;

        static Log4Logger()
        {
            LogConfig = Path.Combine(AppContext.BaseDirectory, "Config", "log4net.config");
            ILoggerRepository repository = LogManager.CreateRepository("SmartDeco");
            XmlConfigurator.ConfigureAndWatch(repository, new FileInfo(LogConfig));
            logImpl = LogManager.GetLogger(repository.Name,"SmartDeco");
        }
        protected override void WriteLog(string message)
        {
            logImpl.Info(message);
        }

        public override void Logger_Error(Exception ex)
        {
            logImpl.Error(ex);
        }

        public override void Logger_Debug(string message)
        {
            logImpl.Debug(message);
        }

        public override void Logger_Fatal(string message)
        {
            logImpl.Fatal(message);
        }

        public override void Logger_Info(string message)
        {
            logImpl.Info(message);
        }

        public override void Logger_Warn(string message)
        {
            logImpl.Warn(message);
        }
    }
}
