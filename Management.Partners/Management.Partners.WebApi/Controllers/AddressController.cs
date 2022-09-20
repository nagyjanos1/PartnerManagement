using Management.Partners.Application.Queries;
using Management.Partners.WebApi.Models.Address;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Management.Addresss.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllByFiltersAsync([FromQuery] GetAllPartnerAddressRequest getAllRequest)
        {
            var query = new GetAllPartnerAddressesQuery
            {
                PartnerId = getAllRequest.PartnerId.ToString(),
                Skip = getAllRequest.Skip,
                Take = getAllRequest.Take,
                OrderBy = getAllRequest.OrderBy,
                IsDescending = getAllRequest.IsDescending
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
        {
            var query = new GetAddressByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddAddressRequest request)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = request.GetCommand();

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAddressRequest request)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = request.GetCommand();

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteAddressRequest request)
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
