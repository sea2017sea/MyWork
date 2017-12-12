using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.IRepository;

namespace Point.com.RepositoryFactory
{
    public class DbSessionDefine : DbSession
    {
        public override string DbConnectionStringBBHomeDb
        {
            get
            {
                return Configurator.DbbbHomeConnectionString;
            }
        }


        public override string DbConnectionStringHolycaDb
        {
            get
            {
                return Configurator.DbHolycaConnectionString;
            }
        }

        public override string DbConnectionStringMLT
        {
            get
            {
                return Configurator.DbMLTConnectionString;
            }
        }

    }


    public class DefineHolycaDb : HolycaDb
    {
        public DefineHolycaDb(string dbConnectionString)
            : base(dbConnectionString)
        {

        }

    }


    public class DefineBBhomeDb : BBHomeDb
    {
        public DefineBBhomeDb(string dbConnectionString)
            : base(dbConnectionString)
        {

        }
    }
}
