using Application.Interfaces.Gateways;
using Infrastructure.Gateways;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddGateways(this IServiceCollection services)
    {
        services.AddScoped<ICountriesGateway, CountriesGateway>();
    }
}
