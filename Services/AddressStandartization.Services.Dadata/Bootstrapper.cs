using Microsoft.Extensions.DependencyInjection;

namespace AddressStandartization.Services.DadataService
{
    public static class Bootstrapper
    {
        public static IServiceCollection addAdresService(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDadataService, DadataService>();
        }

    }
}
