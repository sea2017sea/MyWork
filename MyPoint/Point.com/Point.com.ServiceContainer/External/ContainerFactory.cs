
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.ServiceContainer.Impl;

namespace Point.com.ServiceContainer.External
{
    public class ContainerFactory
    {
        private static IContainer _container;
        public static IContainer GetContainer()
        {
            if (_container == null)
            {
                _container = new ContainerImpl();
            }
            return _container;
        }
    }
}
