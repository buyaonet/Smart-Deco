#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：Entity
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 16:40:11
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartDeco.Domain.Core
{
    /// <summary>
    /// 数据表 基类
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// key 主键Id
        /// </summary>
        [Key]
        [DisplayName("主键Id")]
        [Required(ErrorMessage ="主键不能为空")]
        public Guid Id { get; set; }
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
