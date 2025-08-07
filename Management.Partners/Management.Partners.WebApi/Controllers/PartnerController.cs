using Management.Partners.Application.Partners.Dtos;
using Management.Partners.Application.Partners.Queries;
using Management.Partners.WebApi.Requests;
using Management.Partners.WebApi.Requests.Partner;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Management.Partners.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartnerController : ControllerBase
{
    private readonly IMediator _mediator;

    public PartnerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllByFiltersAsync([FromQuery] GetAllRequest getAllRequest)
    {
        var query = new GetAllPartnersQuery
        {
            Skip = getAllRequest.Skip,
            Take = getAllRequest.Take,
            OrderBy = getAllRequest.OrderBy,
            IsDescending = getAllRequest.IsDescending
        };

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var query = new GetPartnerByIdQuery(id);

        var result = await _mediator.Send(query);
        if (result == PartnerDto.None)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddPartnerRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = request.GetCommand();

        var result = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetByIdAsync),
            new { id = result.Id },
            result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePartnerRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = request.GetCommand();

        var result = await _mediator.Send(command);
        if (result == PartnerDto.None)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeletePartnerRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = request.GetCommand();

        _ = await _mediator.Send(command);

        return NoContent();
    }
}
