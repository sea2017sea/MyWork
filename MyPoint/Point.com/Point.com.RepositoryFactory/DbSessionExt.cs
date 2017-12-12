using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.IRepository;
using Point.com.Repository;

namespace Point.com.RepositoryFactory
{
    public partial class DbSession : IDbSession
    {
    }

    public abstract partial class DbSingleSession : IDbSingSession
    {
        public abstract IUnitOfWork UnitOfWork { get; }

        public int SaveChange()
        {
            return this.UnitOfWork.SaveChanges();
        }

        public IEnumerable<TResult> ExecuteSql<TResult>(string sql, object paras = null)
        {
            return UnitOfWork.ExecuteSql<TResult>(sql, paras);
        }

        public int ExecuteSql(string sql, object paras = null)
        {
            return UnitOfWork.ExecuteSql(sql, paras);
        }

        public void ExecuteSqlNoneQuery(string sql, object paras = null)
        {
            UnitOfWork.ExecuteSqlNoneQuery(sql, paras);
        }
    }
}
