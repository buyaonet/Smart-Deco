#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：User
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 16:39:51
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartDeco.Domain.Core
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class User : Entity
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [Display(Name ="账号")]
        public string Account { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [Display(Name ="用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [Display(Name ="密码")]
        public string PassWord { get; set; }

        /// <summary>
        /// 0 男 1 女
        /// </summary>
        [Required]
        [Display(Name ="性别")]
        [Range(0,1)]
        public int Sex { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        [Display(Name = "地址")]
        public string Address { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name ="创建时间")]
        public int CreateTime { get; set; }

        public virtual List<UserRole> UserRoles{ get; set; }
        public virtual List<Room> Rooms { get; set; }

        public User()
        {            
        }
    }
}
