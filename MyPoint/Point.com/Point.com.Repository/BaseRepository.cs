using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Point.com.IRepository;
using Point.com.Model;

namespace Point.com.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T>, IUnitOfWorkRepository where T : ModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        protected abstract string QueryBySql(T where = null, string order = null);


        protected abstract string GetSqlFromModel(T t, Func<string, string, string> addFunc,
                                        Func<string, string> joinFunc);

        protected abstract string GetWhereSqlFromModel(T t, Func<string, string> joinFunc,
                                             Func<string, string> addFunc = null);

        /// <summary>
        /// 查询对象是否为空（非内存null，而是字段是否有赋值）
        /// </summary>
        /// <param name="t">对象</param>
        /// <returns>true:null false:not null</returns>
        public bool IsNull(T t)
        {
            return GetWhereSqlFromModel(t, s => " AND ").Trim().Length <= 0;
        }

        public long QueryCountBy(T @where = null)
        {
            return ExecuteScalar(QueryCountBySql(where));

        }

        public long QuerySumBy(string columnName, T @where = null)
        {
            return ExecuteScalar(QuerySumBySql(columnName, where));

        }

        public IEnumerable<T> QueryTopBy(int? top, T @where = null, string order = null)
        {
            return DapperSql<T>(QueryTopBySql(top, where, order));
        }


        public IEnumerable<T> QueryBy(T where = null, string order = null)
        {
            var sql = QueryBySql(where, order);
            return DapperSql<T>(sql);
        }

        protected abstract string QueryCountBySql(T where = null);
        protected abstract string QuerySumBySql(string columnName, T where = null);
        protected abstract string QueryTopBySql(int? top, T where = null, string order = null);

        protected abstract string QueryPageBySql(int pageIndex = 1, int pageSize = 20, T where = null, string order = null);
        public IEnumerable<T> QueryPageBy(int pageIndex = 1, int pageSize = 20, T where = null, string order = null)
        {
            if (0 == pageIndex) pageIndex = 1;
            if (0 == pageSize) pageSize = 20;
            var sql = QueryPageBySql(pageIndex, pageSize, where, order);
            return DapperSql<T>(sql);
        }

        private IEnumerable<TY> DapperSql<TY>(string sql)
        {

            using (
                IDbConnection dbConnection =
                    new SqlConnection(_unitOfWork.DbConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    return dbConnection.Query<TY>(sql);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        private long ExecuteScalar(string sql)
        {
            using (
               IDbConnection dbConnection =
                   new SqlConnection(_unitOfWork.DbConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    var command = dbConnection.CreateCommand();
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
                    object obj = command.ExecuteScalar();
                    long result = default(long);
                    if (null != obj)
                    {
                        result = Convert.ToInt64(obj);
                    }
                    return result;
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        public void Add(params T[] items)
        {
            _unitOfWork.RegisterAdded(this, items);
        }



        public void Update(params T[] items)
        {
            _unitOfWork.RegisterChanged(this, items);
        }

        public abstract void AddDataTable(DataTable dataTable);

        public void AddDataTable(DataTable dataTable, string tableName)
        {
            _unitOfWork.RegisterDataTable(dataTable, tableName);
        }

        public abstract string PersistNewItem(params ModelBase[] items);

        public abstract string PersistUpdatedItem(params ModelBase[] items);
    }
}
