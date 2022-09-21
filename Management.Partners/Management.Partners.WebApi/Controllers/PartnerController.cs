using Management.Partners.Application.Commands;
using Management.Partners.Application.Queries;
using Management.Partners.Domain.Partners;
using Management.Partners.WebApi.Models;
using Management.Partners.WebApi.Models.Partner;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Management.Partners.WebApi.Controllers
{
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

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddPartnerRequest request)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = request.GetCommand();

            var result = await _mediator.Send(command);
            if (result == Partner.None)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(new { result.Id });
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePartnerRequest request)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = request.GetCommand();

            var result = await _mediator.Send(command);
            if (result == Partner.None)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeletePartnerRequest request)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = request.GetCommand();

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
