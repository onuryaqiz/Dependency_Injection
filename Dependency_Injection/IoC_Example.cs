using Dependency_Injection.Services;

namespace Dependency_Injection
{
    public class IoC_Example
    {
        public IoC_Example()

        {
            IServiceCollection services = new ServiceCollection(); // built-in IoC
            services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog())); // Bu kendi oluşturduğumuz Container,dır. 
            services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));      // Bu kendi oluşturduğumuz Container,dır. 

            ServiceProvider provider = services.BuildServiceProvider(); // Somut container/provider
            provider.GetService<ConsoleLog>();
            provider.GetService<TextLog>();

        }
    }
}
