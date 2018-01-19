using AutoMapper;
using Inke.Common.Extentions;
using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Model;
using InkeServer.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InkeServer.Service.Impl
{
    public class SysLogService : ServiceBase, ISysLogService
    {
        //标记为注入对象
        [InjectionConstructor]
        public SysLogService() { }

        private static KeySelectors<Log_SysLog, SysLogSortBy> _keySelectors =
            new KeySelectors<Log_SysLog, SysLogSortBy>().Add(SysLogSortBy.SysLog_ID, r => r.SysLog_ID);

        public bool Insert(SysLogInsert model)
        {
            #region Insert

            var sysLog = model.MapTo<Log_SysLog>();
            sysLog.AddTime = DateTime.Now;
            return Insert(sysLog);

            #endregion
        }

        public IPaginationResult<SysLogInfo> Query(SysLogQueryRequest param)
        {
            #region Query
            List<SortingParameter<SysLogSortBy>> sortings = null;
            //构造查询条件
            var query = (from l in Entities.Log_SysLog select l);

            #region 构造查询

            if (null != param)
            {
                //操作类型
                query = query.WhereIf(
                    l => l.SysLog_Type == param.SysLog_Type.Value, param.SysLog_Type.HasValue);

                //关键词
                query = query.WhereIf(
                    l => l.Operator.IndexOf(param.Keyword) > -1 || l.SysLog_Content.IndexOf(param.Keyword) > -1,
                    param.Keyword.NotNullOrEmpty());

                //操作日期
                query = query.WhereIf(
                    l => l.AddTime >= param.StartTime.Value, param.StartTime.HasValue);

                //操作结束日期
                query = query.WhereIf(
                    l => l.AddTime <= param.EndTime.Value, param.EndTime.HasValue);

                #region 构造排序

                if (param.SortingParameters != null && param.SortingParameters.Length > 0)
                {
                    _keySelectors = new KeySelectors<Log_SysLog, SysLogSortBy>();
                    for (int i = 0; i < param.SortingParameters.Length; i++)
                    {
                        SortingDirection direcion = param.SortingParameters[i].OrderDirection == 1 ? 
                            SortingDirection.Ascending : SortingDirection.Descending;
                        sortings = new List<SortingParameter<SysLogSortBy>>();

                        switch (param.SortingParameters[i].OrderField)
                        { 
                                //按ID排序
                            case (int)SysLogSortBy.SysLog_ID:
                                _keySelectors.Add(SysLogSortBy.SysLog_ID, p => p.SysLog_ID);
                                sortings.Add(new SortingParameter<SysLogSortBy>(SysLogSortBy.SysLog_ID, direcion));
                                break;
                                //按类型排序
                            case (int)SysLogSortBy.SysLog_Type:
                                _keySelectors.Add(SysLogSortBy.SysLog_Type, p => p.SysLog_Type);
                                sortings.Add(new SortingParameter<SysLogSortBy>(SysLogSortBy.SysLog_Type, direcion));
                                break;
                                //按操作时间排序
                            case (int)SysLogSortBy.AddTime:
                                _keySelectors.Add(SysLogSortBy.AddTime, p => p.AddTime);
                                sortings.Add(new SortingParameter<SysLogSortBy>(SysLogSortBy.AddTime, direcion));
                                break;
                                //按操作人排序
                            case (int)SysLogSortBy.Operator:
                                _keySelectors.Add(SysLogSortBy.Operator, p => p.Operator);
                                sortings.Add(new SortingParameter<SysLogSortBy>(SysLogSortBy.Operator, direcion));
                                break;
                            default:
                                break;
                        }
                    }
                }

                #endregion
            }

            #endregion 构造查询

            return QueryPaginate<Log_SysLog, SysLogInfo, SysLogSortBy>
                (query, param, _keySelectors, SysLogSortBy.SysLog_ID, sortings);

            #endregion
        }
    }
}
