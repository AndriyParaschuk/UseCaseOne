using Application.Filters;
using Application.Interfaces.Gateways;
using Domain.Entities;
using MediatR;
using static Application.Constants.Constants;

namespace Application.Queries;

public class GetCountriesQuery : IRequest<IReadOnlyCollection<Country>>
{
    public string Search { get; set; } = string.Empty;
    public double? PopulationFilter { get; set; }
    public string Sort { get; set; } = FilterDefaultValues.Ascend;
    public int? CountriesCount { get; set; }
}

public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IReadOnlyCollection<Country>>
{
    private readonly ICountriesGateway _countriesGateway;

    public GetCountriesQueryHandler(ICountriesGateway countriesGateway)
        => _countriesGateway = countriesGateway;

    public async Task<IReadOnlyCollection<Country>> Handle(GetCountriesQuery query, CancellationToken cancellationToken)
    {
        var countries = await _countriesGateway.GetCountriesAsync(cancellationToken);

        return countries
            .Search(query.Search)
            .PopulationFilter(query.PopulationFilter)
            .Sort(query.Sort)
            .Pagination(query.CountriesCount);
    }
}
