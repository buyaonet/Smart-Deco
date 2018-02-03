#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：UserRole
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 16:57:57
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System;
using System.ComponentModel.DataAnnotations;

namespace SmartDeco.Domain.Core
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public partial class UserRole : Entity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Required]
        [Display(Name = "用户Id")]
        public Guid UserId { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        [Required]
        [Display(Name = "角色Id")]
        public Guid RoleId { get; set; }
        public  User User { get; set; }
        public  Role Role { get; set; }
        public UserRole()
        {
        }
    }
}
