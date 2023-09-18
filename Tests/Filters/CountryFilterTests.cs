using Application.Filters;
using Domain.Entities;
using Xunit;
using static Application.Constants.Constants;

namespace Tests.Filters;

public class CountryFilterTests
{
    private static readonly Country[] _countries = GetCountries();

    [Fact]
    public void Search_ShouldReturnCountriesBySearch()
    {
        //Arrange

        //Act
        var result = _countries.Search("Sa");

        //Assert
        Assert.NotEmpty(result);
        Assert.Contains(result, x => x.Name.Common == "USA");
    }

    [Fact]
    public void PopulationFilter_ShouldReturnCountriesByFilter()
    {
        //Arrange

        //Act
        var result = _countries.PopulationFilter(100);

        //Assert
        Assert.NotEmpty(result);
        Assert.Contains(result, x => x.Name.Common == "Ukraine");
    }

    [Theory]
    [InlineData(FilterDefaultValues.Ascend, "Ukraine")]
    [InlineData(FilterDefaultValues.Descend, "USA")]
    [InlineData("invalid", "Ukraine")]
    public void Sort_ShouldReturnSortCountries(string sort, string firstCountryName)
    {
        //Arrange

        //Act
        var result = _countries.Sort(sort);

        //Assert
        Assert.NotEmpty(result);
        Assert.Equal(firstCountryName, result.First().Name.Common);
    }

    [Fact]
    public void Pagination_ShouldReturnPaginatedCountries()
    {
        //Arrange

        //Act
        var result = _countries.Pagination(1);

        //Assert
        Assert.NotEmpty(result);
        Assert.Single(result);
        Assert.Contains(result, x => x.Name.Common == "Ukraine");
    }

    private static Country[] GetCountries()
        => new Country[]
        {
            new()
            {
                Name = new CountryName
                {
                    Common = "Ukraine",
                    Official = "Ukraine"
                },
                Population = 43000000
            },
            new()
            {
                Name = new CountryName
                {
                    Common = "USA",
                    Official = "United States of America"
                },
                Population = 328000000
            }
        };
}
