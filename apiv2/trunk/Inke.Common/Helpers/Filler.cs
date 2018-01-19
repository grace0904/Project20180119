using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Inke.Common.Helpers
{
    /// <summary>
    /// 将弱类型填充为强类型列表的帮助类
    /// </summary>
    public class Filler
    {
        /// <summary>
        /// Datatable转换为List
        /// </summary>
        public static List<T> FillModel<T>(DataTable dt)
        {
            List<T> result = new List<T>();

            T model = default(T);

            if( dt.Columns[0].ColumnName == "rowId" )
            {
                dt.Columns.Remove("rowId");
            }

            foreach( DataRow dr in dt.Rows )
            {
                model = Activator.CreateInstance<T>();
                foreach( DataColumn dc in dr.Table.Columns )
                {
                    try
                    {
                        PropertyInfo pi = model.GetType().GetProperty(dc.ColumnName);
                        if( dr[dc.ColumnName] != DBNull.Value )
                            pi.SetValue(model, dr[dc.ColumnName], null);
                        else
                            pi.SetValue(model, null, null);
                    }
                    catch
                    {
                        continue;
                    }

                }
                result.Add(model);
            }

            return result;
        }
    }
}
