using Microsoft.EntityFrameworkCore;
using SmartDeco.Domain.Core;
using SmartDeco.Domain.Interface;
using SmartDeco.Infrastructure.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SmartDeco.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected SDDbContext Context = new SDDbContext();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private IQueryable<T> Filter(Expression<Func<T, bool>> exp)
        {
            var dbSet = Context.Set<T>().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);
            return dbSet;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            Context.Set<T>().Add(entity);
            return Save();
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entites"></param>
        /// <returns></returns>
        public bool BatchAdd(T[] entites)
        {
            Context.Set<T>().AddRange(entites);
            return Save();
        }
        /// <summary>
        /// 条件 删除
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public bool Delete(Expression<Func<T, bool>> exp)
        {
            var dbSet = Filter(exp);
            Context.Set<T>().RemoveRange(dbSet);
            return Save();
        }
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Save();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> exp)
        {
            return Filter(exp);
        }
        /// <summary>
        /// 单个查询
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public T FindSignle(Expression<Func<T, bool>> exp = null)
        {
            return Context.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }
        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public int GetCount(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp).Count();
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public bool IsExists(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Any(exp);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                LoggerFactory.Instance.Logger_Debug(ex.Message);
                return false;
            }

        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
            return Save();
        }
        /// <summary>
        /// 分页搜索
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="orderby"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public IQueryable<T> Find(int pageindex = 1, int pagesize = 10, Expression<Func<T, bool>> exp = null)
        {
            if (pageindex <= 1)
                pageindex = 1;
            return Filter(exp).Skip(pageindex).Take((pageindex - 1) * pagesize);
        }
    }
}
