using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.ServiceContainer.Impl
{
    internal partial class ContainerImpl : IContainer
    {
        private static Dictionary<string, object> _container;

        public void InitContainer()
        {
            //throw new System.NotImplementedException();
            _container = new Dictionary<string, object>();
            Container.Configer(new ContainerImpl());
        }

        public void Register<TClass, TInterface>(TClass tClass) where TClass : class, TInterface
        {
            _container.Add(typeof(TInterface).FullName, tClass);
        }

        public TInterface Resolve<TInterface>()
        {
            TInterface tInterface = default(TInterface);
            object obj;
            if (_container.TryGetValue(typeof(TInterface).FullName, out obj))
            {
                tInterface = (TInterface)obj;
            }
            return tInterface;
        }

        public bool TryResolve<TInterface>(out TInterface tInterface)
        {
            object obj;
            bool flag = false;
            tInterface = default(TInterface);
            if (_container.TryGetValue(typeof(TInterface).FullName, out obj))
            {
                flag = true;
                tInterface = (TInterface)obj;
            }
            return flag;
        }
    }
}
