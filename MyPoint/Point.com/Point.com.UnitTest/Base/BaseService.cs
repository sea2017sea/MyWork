using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Assembler;
using Point.com.IRepository;
using Point.com.Logging;
using Point.com.Logging.External;
using Point.com.RepositoryFactory;
using Point.com.ServiceImplement;
using ServiceStack.ServiceClient.Web;

namespace Point.com.UnitTest
{
   public class BaseService:INotice
    {
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

        private static JsonServiceClient _omsJsonServiceClient;
        public JsonServiceClient OmsJsonServiceClient
        {
            get
            {
                if (null == _omsJsonServiceClient)
                {
                    _omsJsonServiceClient = new JsonServiceClient("http://192.168.100.110:3000/");
                }
                return _omsJsonServiceClient;
            }
        }
    }
}
