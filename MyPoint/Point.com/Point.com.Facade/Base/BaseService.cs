using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Assembler;
using Point.com.Logging;
using Point.com.Logging.External;
using Point.com.ServiceContainer.External;
using ServiceStack.ServiceInterface;

namespace Point.com.Facade
{
    public class BaseService<T> : Service
    {
        protected TInterface Resolve<TInterface>()
        {
            return ContainerFactory.GetContainer().Resolve<TInterface>();
        }

        protected T ServiceImpl { get; set; }

        public BaseService()
        {
            ServiceImpl = ContainerFactory.GetContainer().Resolve<T>();
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
