using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    /// <summary>
    /// 老板手机报表接口服务类
    /// </summary>
    public interface IBossPhoneService
    {
        /// <summary>
        /// 获取老板手机报表列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<BossReportRecordResult> GetBossReportRecord(MerchantIdRequest param);
        /// <summary>
        /// 新增老板手机报表列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        void Insert(BossPhoneInsert param);
        /// <summary>
        /// 删除老板手机报表列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        void Delete(OperationBaseRequest param); /// <summary>
        /// 修改老板手机报表列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        void Update(BossPhoneUpdate param);
        /// <summary>
        ///根据ID查询老板报表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BossReportRecordInfoResult GetBossReportInfo(string id);
    }
}
