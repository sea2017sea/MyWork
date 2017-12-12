using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using Point.com.Assembler;
using Point.com.Caching;
using Point.com.Caching.External;
using Point.com.IRepository;
using Point.com.Logging;
using Point.com.Logging.External;
using Point.com.RepositoryFactory;
using ServiceStack.ServiceClient.Web;

namespace Point.com.ServiceImplement
{
    public class BaseService : INotice
    {
        private ICacheClientSession _cacheClientSession;
        protected ICacheClientSession CacheClientSession
        {
            get
            {
                if (null == _cacheClientSession)
                {
                    _cacheClientSession = CacheClientSessionIoc.GetCacheClientSession();
                }
                return _cacheClientSession;
            }
        }

        private IDbSession _dbSession;
        protected IDbSession DbSession
        {
            get
            {
                if (null == _dbSession)
                {
                    _dbSession = DbSessionFactory.GetDbSession();
                }
                return _dbSession;
            }
        }

        private IMapper _mapper;
        public IMapper Mapper
        {
            get
            {
                if (null == _mapper)
                {
                    _mapper = AssemblerIoc.GetMapper();
                }
                return _mapper;
            }
        }

        private IUserLogger _logger;
        protected IUserLogger Logger
        {
            get
            {
                if (null == _logger)
                {
                    _logger = LoggerIoc.GetLogger();
                }
                return _logger;
            }
        }
    }
}
