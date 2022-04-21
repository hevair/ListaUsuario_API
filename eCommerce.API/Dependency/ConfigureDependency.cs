using eCommerce.API.Interface;
using eCommerce.API.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.API.Dependency
{
    public class ConfigureDependency
    {
        public static void Dependency(IServiceCollection service){
            service.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}