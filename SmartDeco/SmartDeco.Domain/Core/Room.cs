#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：Room
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 17:13:26
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDeco.Domain.Core
{
    /// <summary>
    /// 用户房屋表
    /// </summary>
    public partial class Room : Entity
    {
        public Room()
        {
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 房间名
        /// </summary>
        public string RoomName { get; set; }
        /// <summary>
        /// 房屋面积
        /// </summary>
        public double Size { get; set; }
        /// <summary>
        /// 房屋图片
        /// </summary>
        public string Pictures { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public int CreateTime { get; set; }
        public User User { get; set; }

    }
}
