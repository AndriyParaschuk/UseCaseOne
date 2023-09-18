using Application.Interfaces.Gateways;
using Domain.Entities;
using System.Text.Json;

namespace Infrastructure.Gateways;

public class CountriesGateway : ICountriesGateway
{
    private readonly HttpClient _httpClient;

    public CountriesGateway(HttpClient httpClient)
        => _httpClient = httpClient;

    public async Task<Country[]> GetCountriesAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all", cancellationToken);

        return JsonSerializer.Deserialize<Country[]>(
            response.Content.ReadAsStringAsync(cancellationToken).Result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Country>();
    }
}
