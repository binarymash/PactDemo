using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BinaryMash.PactDemo.Provider.Windsor.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            InstallControllers(container);

            container.Register(Classes.FromThisAssembly()
                       .Pick()
                       .WithServiceDefaultInterfaces()
                       .Configure(c => c.LifestyleTransient()));
        }

        private static void InstallControllers(IWindsorContainer container)
        {
            container.Register(Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Controller"))
                .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                .LifestyleTransient());
        }
    }
}