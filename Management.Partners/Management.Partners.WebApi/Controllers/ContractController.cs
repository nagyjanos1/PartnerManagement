using Management.Partners.Application.Contracts.Dtos;
using Management.Partners.Application.Contracts.Queries;
using Management.Partners.WebApi.Requests;
using Management.Partners.WebApi.Requests.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Management.Partners.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("All")]
    public async Task<IActionResult> GetAllByFiltersAsync([FromQuery] GetAllRequest getAllRequest)
    {
        var query = new GetAllContractsQuery
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
        var query = new GetContractByIdQuery(id);

        var result = await _mediator.Send(query);
        if (result == ContractDto.None)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddContractRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = request.GetCommand();

        var result = await _mediator.Send(command);
        if (result == ContractDto.None)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return CreatedAtAction(
            nameof(GetByIdAsync),
            new { id = result.Id },
            result
        );
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateContractRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = request.GetCommand();

        var result = await _mediator.Send(command);
        if (result == ContractDto.None)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteContractRequest request)
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
