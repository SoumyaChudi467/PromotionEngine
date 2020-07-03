using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Contracts;

namespace PromotionEngine.Api.Controllers
{
    [Route("promotion")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PromotionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        /// <summary>
        /// Get Total count after applying promotion
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Total price</returns>
        [ProducesResponseType(typeof(RetrieveTotalUsingPromotionsRs), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetrieveTotalUsingPromotionsRs), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RetrieveTotalUsingPromotionsRs), StatusCodes.Status500InternalServerError)]
        [HttpPost("retrieveTotalUsingPromotions")]
        public async Task<IActionResult> RetrieveTotalUsingPromotions([FromBody] RetrieveTotalUsingPromotionsRq request)
        {
           var result = await _mediator.Send(request);
            return Ok(result);
        }
 
    }
}
