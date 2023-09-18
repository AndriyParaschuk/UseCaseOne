using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UseCaseOne.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<IReadOnlyCollection<Country>>> GetCountries(GetCountriesQuery query)
    {
        var request = await _mediator.Send(query);

        return Ok(request);
    }
}
