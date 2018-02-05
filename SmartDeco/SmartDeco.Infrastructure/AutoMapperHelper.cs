#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：AutoMapperHelper
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/5 21:44:01
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using AutoMapper;
using SmartDeco.Infrastructure.Logger;

namespace SmartDeco.Infrastructure
{
    public static class AutoMapperHelper
    {
        /// <summary>
        /// 转换 映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null)
            {
                LoggerFactory.Instance.Logger_Warn($"objw为null");
                return default(T);
            }
            return Mapper.Map<T>(obj);
        }
    }
}
