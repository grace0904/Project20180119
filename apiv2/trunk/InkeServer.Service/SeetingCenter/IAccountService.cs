using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IAccountService
    {
        /// <summary>
        /// 分页查询 账号集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<AccountInfoResult> Query(AccountQueryRequest param);
        /// <summary>
        /// 将员工账号标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>       
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 获得员工账号详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>   
        AccountInfoResult GetInfo(RecordIDRequest param);
        /// <summary>
        /// 新增员工账号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Insert(AddOrUpdateAccountRequest param);
        /// <summary>
        /// 修改员工账号信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Update(AddOrUpdateAccountRequest param);
    }
}
