#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：ConfigHelper
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 21:15:37
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using Microsoft.Extensions.Configuration;
using System.IO;

namespace SmartDeco.Infrastructure
{
    public class ConfigHelper
    {
        public IConfigurationRoot Configuration { get; }

        private ConfigHelper()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }
        private static object obj = new object();
        private static ConfigHelper _Instance;

        public string WwwPath = string.Empty;
        public static ConfigHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (obj)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new ConfigHelper();
                        }
                    }
                }
                return _Instance;
            }
        }

        /// <summary>
        /// 获取节点 apsettingg
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetSection(string key)
        {            
            return Configuration[key];
        }

        /// <summary>
        /// 加载wwwroot路径
        /// </summary>
        /// <param name="path"></param>
        public void SetRoot(string path)
        {
            this.WwwPath = path;
        }
        /// <summary>
        /// 获取wwwrooot路径
        /// </summary>
        /// <returns></returns>
        public string GetRoot()
        {
            return this.WwwPath;
        }
    }
}
