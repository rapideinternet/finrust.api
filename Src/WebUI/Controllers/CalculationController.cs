using FinRust.Application.Calculation.Queries.GetCalculation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinRust.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<decimal>> GetCalculation([FromBody] GetCalculationQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
