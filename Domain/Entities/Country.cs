namespace Domain.Entities;

public class Country
{
    public CountryName Name { get; set; } = new();
    public int Population { get; set; }
}
