using Microsoft.Extensions.DependencyInjection;

namespace DigiMenu.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<ILoginService, LoginService>();
        }
    }
}
