using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inke.Common.Paginations
{
    /// <summary>
    /// 分页查询结果（DAL）
    /// </summary>
    public class PaginationData
    {
        #region Model

        public int TotalCount { get; set; }

        public DataSet Data { get; set; }

        #endregion
    }
}
