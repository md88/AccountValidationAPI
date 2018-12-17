using Microsoft.AspNetCore.Mvc;
using SortingCodeAccountValidationAPI.ViewModels;

namespace SortingCodeAccountValidationAPI.Controllers
{
    /// <summary>
    /// A controller used for validation.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        /// <summary>
        /// Validates a sorting code / account number combination.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>An indication of whether or not the sorting code / account number combination is valid.</returns>
        [Route("sortcode-accountnumber")]
        [HttpPost]
        public IActionResult Post([FromBody] SortCodeAccountValidationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok();
        }     
    }
}
