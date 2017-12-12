using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Point.com.Model;

namespace Point.com.IRepository
{
    public interface IBaseRepository<T> where T : ModelBase
    {
        void Add(params T[] items);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="items">支持两个实体，实体0：被更新的列，实体1：查询的过滤条件</param>
        void Update(params T[] items);

        /*void Delete(params T[] items);*/
        void AddDataTable(DataTable dataTable);

        void AddDataTable(DataTable dataTable, string tableName);

        IEnumerable<T> QueryBy(T where = null, string order = null);

        IEnumerable<T> QueryPageBy(int pageIndex = 1, int pageSize = 20, T where = null, string order = null);

        bool IsNull(T t);

        long QueryCountBy(T where = null);
        long QuerySumBy(string columnName, T where = null);
        IEnumerable<T> QueryTopBy(int? top, T where = null, string order = null);
    }
}
