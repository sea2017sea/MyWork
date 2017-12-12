using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Point.com.Logging.Impl;

namespace Point.com.Logging.External
{
    public class LoggerIoc
    {
        public static ILogger GetLogger()
        {
            string logKey = string.Format("{0}_logger", typeof(LoggerIoc).FullName);
            ILogger logger = (ILogger)CallContext.GetData(logKey);

            if (null == logger)
            {
                logger = new DbLogger(Guid.NewGuid().ToString("N"));
                CallContext.SetData(logKey, logger);
            }

            return logger;
        }
    }
}
