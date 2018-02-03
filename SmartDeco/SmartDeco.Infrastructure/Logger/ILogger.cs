#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：ILogger
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 21:41:47
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
    public interface ILogger
    {
        /// <summary>
        /// 设二级目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        ILogger SetPath(string path);

        #region 级别日志
        /// <summary>
        /// 将message记录到日志文件
        /// </summary>
        /// <param name="message"></param>
        void Logger_Info(string message);
        /// <summary>
        /// 异常发生的日志
        /// </summary>
        /// <param name="message"></param>
        void Logger_Error(Exception ex);
        /// <summary>
        /// 调试期间的日志
        /// </summary>
        /// <param name="message"></param>
        void Logger_Debug(string message);
        /// <summary>
        /// 引起程序终止的日志
        /// </summary>
        /// <param name="message"></param>
        void Logger_Fatal(string message);
        /// <summary>
        /// 引起警告的日志
        /// </summary>
        /// <param name="message"></param>
        void Logger_Warn(string message);
        void Logger_Exception(string message, Action action);
        #endregion

    }
}
