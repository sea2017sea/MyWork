using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Point.com.IRepository;
using Point.com.Model;

namespace Point.com.Repository
{
    public class DataTableKvp
    {
        public DataTable DataTable { get; set; }
        public string TableName { get; set; }
    }

    public delegate IEnumerable<TResult> ExecuteDelegate<out TResult>(SqlConnection connection, string sql, object paras);

    public class ExecuteSqlEntity
    {
        public string CommandText { get; set; }
        public object ComamndParams { get; set; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<ModelBase[], IUnitOfWorkRepository> addedEntities;
        private Dictionary<ModelBase[], IUnitOfWorkRepository> changedEntities;
        private Dictionary<ModelBase[], IUnitOfWorkRepository> deletedEntities;
        private List<DataTableKvp> addedDatables;
        private List<ExecuteSqlEntity> executeSqlEntities;



        public UnitOfWork(string dbConnectionString)
        {
            this.addedEntities = new Dictionary<ModelBase[],
                IUnitOfWorkRepository>();
            this.changedEntities = new Dictionary<ModelBase[],
                IUnitOfWorkRepository>();
            this.deletedEntities = new Dictionary<ModelBase[],
                IUnitOfWorkRepository>();
            this.addedDatables = new List<DataTableKvp>();

            this.executeSqlEntities = new List<ExecuteSqlEntity>();

            DbConnectionString = dbConnectionString;

        }

        public string DbConnectionString { get; set; }


        #region IUnitOfWork Members

        public void RegisterAdded(
            IUnitOfWorkRepository repository, params ModelBase[] entity)
        {
            this.addedEntities.Add(entity, repository);
        }

        public void RegisterChanged(
            IUnitOfWorkRepository repository, params ModelBase[] entity)
        {
            this.changedEntities.Add(entity, repository);
        }


        public void RegisterDataTable(
            DataTable dataTable, string tableName)
        {
            this.addedDatables.Add(new DataTableKvp()
            {
                DataTable = dataTable,
                TableName = tableName
            });
        }

        /// <summary>
        /// 立即执行的单独执行的Sql 有返回值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public IEnumerable<TResult> ExecuteSql<TResult>(string sql, object paras)
        {
            using (var dbConnection = this.OpenDbConnection())
            {
                try
                {
                    return dbConnection.Query<TResult>(sql, paras);
                }
                catch (Exception exception)
                {
                    throw new Exception(string.Format("异常Sql:{0}", sql), exception);
                }
            }
        }

        /// <summary>
        /// 立即执行，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql, object paras)
        {
            using (var dbConnection = this.OpenDbConnection())
            {
                try
                {
                    return dbConnection.Execute(sql, paras);
                }
                catch (Exception exception)
                {
                    throw new Exception(string.Format("异常Sql:{0}", sql), exception);
                }
            }
        }

        /// <summary>
        /// 执行sql，没有返回值，有事务保障，需要SaveChange才会执行
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        public void ExecuteSqlNoneQuery(string sql, object paras)
        {
            /*using (var dbConnection = this.OpenDbConnection())
            {
                dbConnection.Query(sql, paras);
            }*/


            this.executeSqlEntities.Add(new ExecuteSqlEntity()
            {
                CommandText = sql,
                ComamndParams = paras
            });
        }



        /// <summary>
        /// Init Sql Connection 
        /// </summary>
        /// <returns></returns>
        private IDbConnection OpenDbConnection()
        {
            IDbConnection dbConnection = new SqlConnection(DbConnectionString);
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }
            return dbConnection;
        }


        public int SaveChanges()
        {
            int effectRows = default(int);
            using (IDbConnection dbConnection = new SqlConnection(DbConnectionString))
            {
                try
                {
                    if (dbConnection.State != ConnectionState.Open)
                    {
                        dbConnection.Open();
                    }
                    using (var transaction = dbConnection.BeginTransaction())
                    {
                        string sql = string.Empty;
                        try
                        {
                            foreach (ModelBase[] entity in this.addedEntities.Keys)
                            {
                                sql = this.addedEntities[entity].PersistNewItem(entity);
                                effectRows = dbConnection.Execute(sql, null, transaction);
                            }

                            foreach (ModelBase[] entity in this.changedEntities.Keys)
                            {
                                sql = this.changedEntities[entity].PersistUpdatedItem(entity);
                                effectRows = dbConnection.Execute(sql, null, transaction);
                            }

                            foreach (DataTableKvp dataTableKvp in addedDatables)
                            {
                                using (
                                    SqlBulkCopy bulkCopy = new SqlBulkCopy((SqlConnection)dbConnection,
                                                                           SqlBulkCopyOptions.Default,
                                                                           (SqlTransaction)transaction))
                                {
                                    bulkCopy.DestinationTableName = dataTableKvp.TableName;
                                    bulkCopy.WriteToServer(dataTableKvp.DataTable);
                                }
                            }
                            foreach (var executeSqlEntity in executeSqlEntities)
                            {
                                effectRows = dbConnection.Execute(executeSqlEntity.CommandText, executeSqlEntity.ComamndParams, transaction);
                            }

                            transaction.Commit();
                        }
                        catch (Exception exception)
                        {
                            transaction.Rollback();
                            throw new Exception(string.Format("异常Sql:{0}", sql), exception);
                        }
                    }
                }
                finally
                {
                    dbConnection.Close();
                    this.deletedEntities.Clear();
                    this.addedEntities.Clear();
                    this.changedEntities.Clear();
                    this.addedDatables.Clear();
                    this.executeSqlEntities.Clear();
                }
            }
            return effectRows;
        }

        #endregion
    }
}
