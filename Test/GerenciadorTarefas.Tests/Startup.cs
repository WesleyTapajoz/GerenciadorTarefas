using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorTarefas.Testes
{
    public class Startup
    {
        private static IConfiguration _configuration;

        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new Startup().GetConfiguration();
                }

                return _configuration;
            }
        }

        public IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile($"appsettings.LOCAL.json")
                .Build();
        }

        public static ServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            return services.BuildServiceProvider();
        }
    }
}
