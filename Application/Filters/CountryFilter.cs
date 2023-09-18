using Domain.Entities;
using static Application.Constants.Constants;

namespace Application.Filters;

public static class CountryFilter
{
    public static Country[] Search(this Country[] countries, string search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            countries = countries
                .Where(x => x.Name.Common.Contains(search.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        return countries;
    }

    public static Country[] PopulationFilter(this Country[] countries, double? population)
    { 
        if (population.HasValue)
        {
            countries = countries
                .Where(x => x.Population <= population * FilterDefaultValues.Multiplayer)
                .ToArray();
        }

        return countries;
    }

    public static Country[] Sort(this Country[] countries, string sort)
        => sort switch
        {
            FilterDefaultValues.Ascend => countries.OrderBy(x => x.Name.Common).ToArray(),
            FilterDefaultValues.Descend => countries.OrderByDescending(x => x.Name.Common).ToArray(),
            _ => countries
        };

    public static Country[] Pagination(this Country[] countries, int? countriesCount)
    {
        if (countriesCount.HasValue)
        {
            countries = countries
                .Take(countriesCount.Value)
                .ToArray();
        }

        return countries;
    }
}
