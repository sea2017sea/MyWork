using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using Point.com.Logging.Extend;

namespace Point.com.Logging.Impl
{
    internal class DbLogger : ILogger
    {
        private static bool _isDebugEnabled;
        private static bool _isInfoEnabled;
        private static bool _isWarnEnabled;

        public bool IsDebugEnabled
        {
            get { return _isDebugEnabled; }
            set { _isDebugEnabled = value; }
        }

        public bool IsInfoEnabled
        {
            get { return _isInfoEnabled; }
            set { _isInfoEnabled = value; }
        }

        public bool IsWarnEnabled
        {
            get { return _isWarnEnabled; }
            set { _isWarnEnabled = value; }
        }

        private string _key = string.Empty;

        private static readonly List<GlobalRecord> Container = new List<GlobalRecord>();
        private void Write(int level, string queryKeyWord, string action, string content, string address = null)
        {
            Container.AddSynchronized(new GlobalRecord()
            {
                FAction = action,
                FAddress = address,
                FContent = content,
                FKey = _key,
                FLevel = level,
                RowCeateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                KeyWord = queryKeyWord
            });
        }
        private void DataTable2Db(DataTable dataTable)
        {
            using (IDbConnection dbConnection = new SqlConnection(Configurator.DbConnectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                using (var transaction = dbConnection.BeginTransaction())
                {

                    try
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy((SqlConnection)dbConnection,
                                                                                  SqlBulkCopyOptions.Default,
                                                                                  (SqlTransaction)transaction))
                        {
                            bulkCopy.DestinationTableName = "GlobalRecord";
                            bulkCopy.WriteToServer(dataTable);
                        }
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        //报警！~~
                        throw new Exception("GlobalRecord持久化异常", exception);
                    }

                }
            }

        }
        public DbLogger(string key)
        {
            _key = key;

            //这些是缓存的 所以不能写死
         /*   _isDebugEnabled = true;
            _isInfoEnabled = true;
            _isWarnEnabled = true;*/
        }



        public void InitLogger()
        {
            while (true)
            {
                TimeSpan timeSpan = new TimeSpan(0, 0, 10);
                try
                {
                    //IService service = ServiceIoc.GetService();
                    //timeSpan = service.WriteLogTimeSpanImpl.Value;
                }
                catch (Exception exception)
                {
                    /*_logger.Write(LoggerLevel.Error, string.Empty, "LogOperatorImpl",
                                 exception.ToString());*/
                }
                Thread.Sleep(timeSpan);
                this.PersistLogs();
            }
        }


        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="queryKeyWord">查询关键字(必填)</param>
        /// <param name="action"></param>
        /// <param name="content"></param>
        /// <param name="address"></param>
        public void Write(LoggerLevel level, string queryKeyWord, string action, string content, string address = null)
        {
            switch (level)
            {
                case LoggerLevel.Debug:
                    if (_isDebugEnabled)
                        this.Write((int)level, queryKeyWord, action, content, address);
                    break;
                case LoggerLevel.Info:
                    if (_isInfoEnabled)
                        this.Write((int)level, queryKeyWord, action, content, address);
                    break;
                case LoggerLevel.Warn:
                    if (_isWarnEnabled)
                        this.Write((int)level, queryKeyWord, action, content, address);
                    break;
                case LoggerLevel.Error:
                    this.Write((int)level, queryKeyWord, action, content, address);
                    break;
                case LoggerLevel.Fault:
                    this.Write((int)level, queryKeyWord, action, content, address);
                    break;
            }
        }


        public void PersistLogs()
        {
            GlobalRecord[] logs = null;
            lock (Container)
            {
                if (Container.Count <= 0)
                {
                    return;
                }
                logs = Container.ToArray();
                Container.Clear();
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("SysNo"),
                    new DataColumn("Key"),
                    new DataColumn("KeyWord"), 
                    new DataColumn("Level"),
                    new DataColumn("Action"),
                    new DataColumn("Content"),
                    new DataColumn("Address"),
                    new DataColumn("RowCreatDate")
                });

            foreach (var log in logs)
            {
                object[] values = new object[8];
                values[0] = (string.Empty);
                values[1] = (log.FKey);
                values[2] = (log.KeyWord);
                values[3] = (log.FLevel);
                values[4] = (log.FAction);
                values[5] = (log.FContent);
                values[6] = (log.FAddress);
                values[7] = (log.RowCeateDate);
                dataTable.Rows.Add(values);
            }
            this.DataTable2Db(dataTable);
        }
    }

    class GlobalRecord
    {
        public int SysNo { get; set; }
        public string FKey { get; set; }
        public string KeyWord { get; set; }
        public Nullable<int> FLevel { get; set; }
        public string FAction { get; set; }
        public string FContent { get; set; }
        public string FAddress { get; set; }
        public string RowCeateDate { get; set; }
        public Nullable<System.DateTime> RowModifyDate { get; set; }
    }
}
