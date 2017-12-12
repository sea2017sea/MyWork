using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Logging
{

    public interface ISystemLogger : IUserLogger
    {
        void PersistLogs();
        void InitLogger();

        bool IsDebugEnabled
        {
            get;
            set;
        }

        bool IsInfoEnabled
        {
            get;
            set;
        }

        bool IsWarnEnabled
        {
            get;
            set;
        }
    }

    public interface IUserLogger
    {
        void Write(LoggerLevel level, string queryKeyWord, string action, string content, string address = null);
    }

    public interface ILogger : ISystemLogger
    {

    }
}
