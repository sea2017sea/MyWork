using System.Collections.Generic;
using System.Data;
using Point.com.Model;

namespace Point.com.IRepository
{
    public interface IUnitOfWork
    {
        void RegisterAdded(IUnitOfWorkRepository repository, params ModelBase[] items);
        void RegisterChanged(IUnitOfWorkRepository repository, params ModelBase[] items);
        //void RegisterRemoved(IUnitOfWorkRepository repository, params ModelBase[] items);
        void RegisterDataTable(DataTable dataTable, string tableName);

        int SaveChanges();

        IEnumerable<TResult> ExecuteSql<TResult>(string sql, object paras);
        int ExecuteSql(string sql, object paras);
        void ExecuteSqlNoneQuery(string sql, object paras);

        string DbConnectionString { get; set; }
    }
}
