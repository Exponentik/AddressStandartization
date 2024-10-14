using AddressStandartization.Services.DadataService;
using AddressStandartization.Services.Settings;

namespace AddressStandartization.Api;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddLogSettings()
            .AddDadataSettings()
            .AddHttpClient()
            .addAdresService();
        
        return services;
    }
}
