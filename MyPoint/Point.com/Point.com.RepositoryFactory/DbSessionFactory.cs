using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Point.com.IRepository;

namespace Point.com.RepositoryFactory
{
    public class DbSessionFactory
    {
        public static IDbSession GetDbSession()
        {
            string dbSessionKey = string.Format("{0}_DbSession", typeof (DbSessionFactory).Name);
            IDbSession dbSession = (IDbSession) CallContext.GetData(dbSessionKey);

            if (dbSession == null)
            {
                dbSession = new DbSessionDefine();
                CallContext.SetData(dbSessionKey, dbSession);
            }

            return dbSession;
        }
    }
}
