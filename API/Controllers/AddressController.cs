using AddressStandartization.Services.DadataService;
using AddressStandartization.Services.DadataService.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IDadataService _dadataService;
        private readonly IMapper _mapper;

        public AddressController(IDadataService dadataService, IMapper mapper)
        {
            _dadataService = dadataService;
            _mapper = mapper;
        }

        [HttpGet("standardize")]
        public async Task<IActionResult> StandardizeAddress([FromQuery] string rawAddress)
        {
            if (string.IsNullOrWhiteSpace(rawAddress))
            {
                return BadRequest("Address is required");
            }

            var standardizedAddress = await _dadataService.StandardizeAddressAsync(rawAddress);
            if (standardizedAddress == null)
            {
                return StatusCode(500, "Error standardizing address");
            }

            var result = _mapper.Map<AddressDto>(standardizedAddress);
            return Ok(result);
        }
    }
}
