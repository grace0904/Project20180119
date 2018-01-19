using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface ISeatClassService
    {
        /// <summary>
        /// 分页查询座位类型
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IPaginationResult<SeatClassQueryResult> Query(SeatClassQueryRequest param);

        /// <summary>
        /// 新增座位类型
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>        
        void Insert(SeatClassInsert model);

        /// <summary>
        /// 修改座位类型
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>        
        void Update(SeatClassUpdate model);

        /// <summary>
        /// 删除座位类型
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>        
        void Delete(OperationBaseRequest param);
        /// <summary>
        /// 根据ID 获取相关座位类型信息
        /// </summary>
        /// <param name="Shop_ID">店铺ID</param>
        /// <returns></returns>
        SeatClassQueryResult GetSeatClassIdAndName(RecordIDRequest param);
    }
}
