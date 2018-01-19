using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Inke.Common.Helpers
{
    /// <summary>
    /// DDataTable 转换成对象
    /// </summary>
    public static class DataTableConvert 
    {
        public static List<T> GetTList<T>(this DataSet ds)
        {
            List<T> List = new List<T>();
            if (ds != null && ds.Tables.Count > 0)
            {
                List = ConvertTo<T>(ds.Tables[0]).ToList();
            }
            return List;
        }

        public static T GetTModels<T>(this DataSet ds) where T : new()
        {
            T objects = new T();
            if (ds != null && ds.Tables.Count > 0)
            {
              objects=  ConvertTo<T>(ds.Tables[0]).FirstOrDefault();
            }
            return objects;
        }
    

        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }
            List<DataRow> rows = new List<DataRow>(); 
            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }
            return ConvertTo<T>(rows);

        } 

        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;
            if (rows != null)
            {
                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
            return list;

        }
         
        public static T CreateItem<T>(DataRow row)
        {

            T obj = default(T);

            if (row != null)
            {
                obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        if (null == value || DBNull.Value == value) continue;
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {  //You can log something here     

                        //throw;    
                    }

                }

            }



            return obj;
        }

        /// <summary>
        /// 过滤条件的Datatable
        /// </summary>
        /// <param name="dt">需要过滤的DataTable</param>
        /// <param name="conditions">过滤的表达式</param>
        /// <returns></returns>
        public static DataTable DataTableSelect(DataTable dt,string conditions)
        {
            DataTable newdt = new DataTable(); 
            newdt = dt.Clone(); // 克隆dt 的结构，包括所有 dt 架构和约束,并无数据； 
            DataRow[] rows = dt.Select(conditions); // 从dt 中查询符合条件的记录； 
            foreach (DataRow row in rows)  // 将查询的结果添加到dt中； 
            { 
                 newdt.Rows.Add(row.ItemArray); 
            }
            return newdt;
        }

        /*Converts List To DataTable*/
        public static DataTable ToDataTable<TSource>(this IList<TSource> data)
        {
            DataTable dataTable = new DataTable(typeof(TSource).Name);
            PropertyInfo[] props = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (TSource item in data)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        /*Converts DataTable To List*/
        public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
        {
            var dataList = new List<TSource>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                 select new { Name = aProp.Name, Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType }).ToList();
            var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                     select new { Name = aHeader.ColumnName, Type = aHeader.DataType }).ToList();
            var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var aTSource = new TSource();
                foreach (var aField in commonFields)
                {
                    PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                    var value = (dataRow[aField.Name] == DBNull.Value) ? null : dataRow[aField.Name]; //if database field is nullable
                    propertyInfos.SetValue(aTSource, value, null);
                }
                dataList.Add(aTSource);
            }
            return dataList;
        }

       
    }
}
