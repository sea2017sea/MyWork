using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.RepositoryFactory
{
    public class DbDefineSession : DbSession
    {
        public override IRepository.IHolycaDb HolycaDb
        {
            get
            {
                //return base.HolycaDb;
                return new DefineHolycaDb(DbConnectionStringHolycaDb);
            }
        }
    }

   
}
