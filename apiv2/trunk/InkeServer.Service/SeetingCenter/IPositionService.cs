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
    /// 商家职位服务接口
    /// </summary>
    public interface IPositionService
    {
        /// <summary>
        /// 新增商家职位
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Insert(PositionAddOrUpdateRequest param);

        /// <summary>
        /// 修改商家职位信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Update(PositionAddOrUpdateRequest param);

        /// <summary>
        /// 删除商家职位
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 分页查询商家职位
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MerchantPositionInfo> Query(MerchantIdPageRequest param);
        /// <summary>
        /// 获取商家职位列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IList<MerchantPositionInfo> GetList(MerchantIdRequest param);
        /// <summary>
        ///  获取 职位详细信息 包括（职位菜单权限）
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ShopPositionPowerInfoResult GetPositionPowerInfo(RecordIDRequest param);
        /// <summary>
        /// 查询商家对应的所有菜单权限(包括所有终端)
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<SysPositionPower> GetAllSysPowerList(MerchantIdRequest param);
    }
}
