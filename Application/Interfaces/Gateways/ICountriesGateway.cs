using Domain.Entities;

namespace Application.Interfaces.Gateways;

public interface ICountriesGateway
{
    Task<Country[]> GetCountriesAsync(CancellationToken cancellationToken);
}
