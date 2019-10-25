using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using IDAL;
using IBLL;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Core.Lifetime;

namespace IOC
{
    public class AutoFacHelper
    {
        private static IContainer Container
        {
            get
            {
                string DLLAssemblyName = ConfigurationSettings.AppSettings["DLLAssembly"];
                string BLLAssemblyName = ConfigurationSettings.AppSettings["BLLAssembly"];

                Assembly DLL = Assembly.Load(DLLAssemblyName);
                Assembly BLL = Assembly.Load(BLLAssemblyName);

                Type tDLLSessionFactory = DLL.GetType(DLLAssemblyName + ".DBSessionFactory");
                Type tBLLSession = BLL.GetType(BLLAssemblyName + ".BLLSession");

                var builder = new ContainerBuilder();

                builder.RegisterType(tDLLSessionFactory).As<IDBSessionFactory>();
                builder.RegisterType(tBLLSession).As<IBLLSession>();

                var _containerBuilder = builder;
                return _containerBuilder.Build();
            }
        }

        public static T Resolve<T>() where T : class
        {
            ILifetimeScope scope;
            try
            {
                scope = AutofacDependencyResolver.Current.RequestLifetimeScope;
            }
            catch (Exception)
            {
                //we can get an exception here if RequestLifetimeScope is already disposed
                //for example, requested in or after "Application_EndRequest" handler
                //but note that usually it should never happen

                //when such lifetime scope is returned, you should be sure that it'll be disposed once used (e.g. in schedule tasks)
                scope = Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
            return scope.Resolve<T>();
        }

    }
}
