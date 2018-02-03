#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：LoggerFactory
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 21:42:42
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeco.Infrastructure.Logger
{
    public class LoggerFactory : ILogger
    {
        private LoggerFactory()
        {
            // 默认保存到文件
            string type = ConfigHelper.Instance.GetSection("LogType:Type") ?? "file";
           // string type = "file";
            switch (type)
            {
                case "file":
                    iLogger = new FileLogger();
                    break;
                case "log4net":
                    iLogger = new Log4Logger();
                    break;
                default:
                    throw new Exception("日志配置出现异常！");
            }

        }
        /// <summary>
        /// 线程锁
        /// </summary>
        private static object lockObj = new object();
        /// <summary>
        /// 日志工厂
        /// </summary>
        private static LoggerFactory _Instance;
        /// <summary>
        /// 生成对象
        /// </summary>
        public static LoggerFactory Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (lockObj)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new LoggerFactory();
                        }
                    }
                }
                return _Instance;
            }
        }

        /// <summary>
        /// 日志提供者，只在本类中实例化
        /// </summary>
        private ILogger iLogger;


        public void Logger_Exception(string message, Action action)
        {
            iLogger.Logger_Exception(message, action);
        }
        /// <summary>
        /// Debug级别的日志
        /// </summary>
        /// <param name="message"></param>
        public void Logger_Debug(string message)
        {

            iLogger.Logger_Debug(message);
        }
        /// <summary>
        /// Info级别的日志
        /// </summary>
        /// <param name="message"></param>
        public void Logger_Info(string message)
        {
            iLogger.Logger_Info(message);
        }
        /// <summary>
        /// Warn级别的日志
        /// </summary>
        /// <param name="message"></param>
        public void Logger_Warn(string message)
        {

            iLogger.Logger_Warn(message);
        }
        /// <summary>
        /// Error级别的日志
        /// </summary>
        /// <param name="ex"></param>
        public void Logger_Error(Exception ex)
        {

            iLogger.Logger_Error(ex);
        }
        /// <summary>
        /// Fatal级别的日志
        /// </summary>
        /// <param name="message"></param>
        public void Logger_Fatal(string message)
        {
            iLogger.Logger_Fatal(message);
        }

        public ILogger SetPath(string path)
        {
            iLogger.SetPath(path);
            return iLogger;
        }
    }
}
