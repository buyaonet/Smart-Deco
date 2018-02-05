using SmartDeco.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SmartDeco.Domain.Interface
{
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// 查询 单个
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        T FindSignle(Expression<Func<T, bool>> exp = null);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        bool IsExists(Expression<Func<T, bool>> exp);
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        IQueryable<T> Find(Expression<Func<T, bool>> exp);
        /// <summary>
        /// 分页搜索
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="orderby"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        IQueryable<T> Find(int pageindex = 1, int pagesize = 10,
          Expression<Func<T, bool>> exp = null);
        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        int GetCount(Expression<Func<T, bool>>exp=null);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(T entity);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entites"></param>
        /// <returns></returns>
        bool BatchAdd(T[] entites);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="exp">条件</param>
        /// <returns></returns>
        bool Delete(Expression<Func<T,bool>>exp);
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete(T t);
        /// <summary>
        /// 单个更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(T t);
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        bool Save();


    }
}
