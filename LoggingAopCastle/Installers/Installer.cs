using Castle.DynamicProxy;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LoggingAopCastle.Aspects;
using LoggingAopCastle.Workers;
using LoggingAopCastle.Workers.Interfaces;

namespace LoggingAopCastle.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDoStuff>().ImplementedBy<DoStuff>());

            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig()); 

            container.Register(Component.For<IInterceptor>().ImplementedBy<MyInterceptor>()); 
        }
    }
}
