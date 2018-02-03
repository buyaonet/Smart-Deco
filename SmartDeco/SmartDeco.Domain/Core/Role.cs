#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：Role
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 16:55:11
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartDeco.Domain.Core
{
    /// <summary>
    /// 角色表
    /// </summary>
    public partial class Role : Entity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required]
        [Display(Name = "角色名称")]
        public string RoleName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [Display(Name = "创建时间")]
        public int CreateTime { get; set; }

        public  List<UserRole> UserRoles { get; set; } 
        public Role()
        {
        }
    }
}
