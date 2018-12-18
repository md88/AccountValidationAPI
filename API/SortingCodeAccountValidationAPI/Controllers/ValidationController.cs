using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SortingCodeAccountValidationAPI.Domain.Model.Requests;
using SortingCodeAccountValidationAPI.Domain.Services;
using SortingCodeAccountValidationAPI.ViewModels;

namespace SortingCodeAccountValidationAPI.Controllers
{
    /// <summary>
    /// A controller used for validation.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/validation")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        /// <summary>
        /// The validation service.
        /// </summary>
        private readonly IValidationService validationService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationController"/> class.
        /// </summary>
        /// <param name="validationService">The validation service.</param>
        /// <param name="mapper">The mapper.</param>
        public ValidationController(IValidationService validationService, IMapper mapper)
        {
            this.validationService = validationService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Validates a sorting code / account number combination.
        /// </summary>
        /// <param name="request">The sorting code and account number to be validated.</param>
        /// <returns>An indication of whether or not the sorting code / account number combination is valid.</returns>
        [Route("sortcode-accountnumber")]
        [HttpPost]
        public IActionResult Post([FromBody] SortingCodeAccountValidationViewModel request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var model = this.mapper.Map<SortingCodeAccountValidationRequest>(request);
            var response = this.validationService.ValidateSortingCodeAndAccountNumber(model);

            if (!response.Success)
            {
                return this.BadRequest(response.Message);
            }

            return this.Ok();
        }     
    }
}
