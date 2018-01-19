using AutoMapper;
using EntityFramework.Extensions;
using Inke.Common.Extentions;
using Inke.Common.Paginations;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InkeServer.DataMapping
{
    public class InkeServerEntities : Entities
    {
        [InjectionConstructor]
        public InkeServerEntities() : base() { }
    };

    public abstract class ServiceBase
    {
        //注入实体类
        [Dependency]
        public InkeServerEntities Entities { get; set; }

        #region 实验用(稳定性验证未通过)

        public virtual bool Insert<TEntity>(TEntity entity) where TEntity : class
        {
            Entities.Set<TEntity>().Add(entity);
            return Entities.SaveChanges() > 0;
        }

        public virtual bool Update<TEntity>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : class
        {
            return Entities.Set<TEntity>().Where(predicate).Update(updateExpression) > 0;
        }

        public virtual bool Delete<TEntity>(Expression<Func<TEntity, bool>> filterExpression) where TEntity : class
        {
            return Entities.Set<TEntity>().Where(filterExpression).Delete() > 0;
        }

        public virtual List<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return Entities.Set<TEntity>().ToList();
        }

        /// <summary>
        /// 分页通用方法（支持多表查询）
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TInfo"></typeparam>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<TInfo> QueryPaginate<TSource, TInfo>(
            IQueryable<TSource> query, PaginationRequest param,
            KeySelectors<TSource, DefaultSortBy> _keySelector) where TSource : class
        {
            return QueryPaginate<TSource, TInfo, DefaultSortBy>(query, param, _keySelector, DefaultSortBy.Default);
        }

        /// <summary>
        /// 分页通用方法（支持多表查询）
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TInfo"></typeparam>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="_keySelector"></param>
        /// <param name="defaultSortBy"></param>
        /// <returns></returns>
        public virtual IPaginationResult<TInfo> QueryPaginate<TSource, TInfo, TSortBy>(
            IQueryable<TSource> query,
            PaginationRequest param,
            KeySelectors<TSource, TSortBy> _keySelector,
            TSortBy defaultSortBy) where TSource : class
        {
            return QueryPaginate<TSource, TInfo, TSortBy>(query, param, _keySelector, defaultSortBy, null);
        }

        /// <summary>
        /// 分页通用方法（支持多表查询）
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TInfo"></typeparam>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="_keySelector"></param>
        /// <param name="defaultSortBy"></param>
        /// <param name="sortings"></param>
        /// <returns></returns>
        public virtual IPaginationResult<TInfo> QueryPaginate<TSource, TInfo, TSortBy>(
            IQueryable<TSource> query,
            PaginationRequest param,
            KeySelectors<TSource, TSortBy> _keySelector,
            TSortBy defaultSortBy,
            List<SortingParameter<TSortBy>> sortings) where TSource : class
        {
            //查询总数
            var futureCount = query.FutureCount();

            //创建分页参数
            //var paging = PaginationHelper.GetPaging(param.PageIndex, param.PageSize, defaultSortBy);
            var paging = PaginationHelper.GetPaging(param.PageIndex, param.PageSize, defaultSortBy, param.SortingParameters == null ? 2 : param.SortingParameters[0].OrderDirection);
            if (sortings != null && sortings.Count > 0)
                paging.Sortings = sortings.ToArray();

            //分页处理
            var future = query.Paginater(_keySelector, paging).Future();

            //获取总数
            var totalCount = futureCount.Value;

            //获取当前页数据
            var list = future.ToList();

            //转换为视图
            var listInfo = list.MapTo<TInfo>();

            return new PaginationResult<TInfo> { Items = listInfo, TotalCount = totalCount };
        }

        #endregion

        public void Dispose()
        {
            if (Entities != null)
                Entities.Dispose();
            Entities = null;
        }
    }
}
