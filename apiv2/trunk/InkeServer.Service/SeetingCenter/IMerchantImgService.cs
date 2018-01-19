using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IMerchantImgService
    {
        /// <summary>
        /// 添加商家图片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Insert(AddOrUpdateMerchantImg param);
        /// <summary>
        ///  更新商家图片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Update(AddOrUpdateMerchantImg param);
        /// <summary>
        /// 删除商家图片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 根据图片地址删除商家图片
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool DeleteByUrl(MerchantImgDelete param);
        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        MerchantImg GetInfo(RecordIDRequest param);
        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<MerchantImg> GetList(MerchantImgListRequest param);
    }
}
