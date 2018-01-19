using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    /// <summary>
    /// 店铺员工服务接口
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// 新增店铺员工
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Insert(EmployeeAddOrUpdateRequest param);

        /// <summary>
        /// 修改店铺员工信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Update(EmployeeAddOrUpdateRequest param);

        /// <summary>
        /// 删除店铺员工
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 获取店铺员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EmploeeQueryResult GetInfo(RecordIDRequest param);
        /// <summary>
        /// 分页查询店铺员工
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<EmploeeQueryResult> Query(EmploeeQueryRequest param);
        /// <summary>
        /// 获取店铺员工列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IList<EmployeeInfo> GetListByShopId(MerchantAndShopIdRequest param);
        /// <summary>
        /// 取得指定店铺所有未绑定账号的员工列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IList<EmployeeIDAndName> GetShopEmployeeListNoHasAccountID(MerchantAndShopIdRequest param);
    }
}
