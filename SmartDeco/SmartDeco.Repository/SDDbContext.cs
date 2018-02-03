#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2017 ZyCoder
// 版权所有。 
//
// 文件名：SDDbContext
// 
// 创建者：名字 (zycoder)
// 时间：2018/2/3 16:37:04
//
// 版本：V1.0.0
// 网站: http://www.cnblogs.com/zycoder
//----------------------------------------------------------------*/
#endregion

using Microsoft.EntityFrameworkCore;
using SmartDeco.Domain.Core;

namespace SmartDeco.Repository
{
    public class SDDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SmartDecoDB;User ID=sa;Password=123456");
            }
        }
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// 用户角色表
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }
        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<Role> Roles { get; set; }
        /// <summary>
        /// 房屋表
        /// </summary>
        public DbSet<Room> Rooms { get; set; }
    }
}
