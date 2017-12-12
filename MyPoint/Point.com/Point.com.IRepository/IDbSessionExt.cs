using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.IRepository
{
    public partial interface IDbSession
    {
    }

    public partial interface IDbSingSession
    {
        int SaveChange();
        int ExecuteSql(string sql, object paras = null);
        IEnumerable<TResult> ExecuteSql<TResult>(string sql, object paras = null);
        void ExecuteSqlNoneQuery(string sql, object paras = null);
    }
}
