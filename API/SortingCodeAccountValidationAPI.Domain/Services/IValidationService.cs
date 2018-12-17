using SortingCodeAccountValidationAPI.Domain.DependencyInjection;
using SortingCodeAccountValidationAPI.Domain.Model;

namespace SortingCodeAccountValidationAPI.Domain.Services
{
    /// <summary>
    /// A validation service.
    /// </summary>
    /// <seealso cref="SortingCodeAccountValidationAPI.Domain.DependencyInjection.ITransientService" />
    public interface IValidationService : ITransientService
    {
        /// <summary>
        /// Validates the sorting code and account.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A response to indicate if the request was valid and reason why if not.</returns>
        IServiceResponse ValidateSortingCodeAndAccountNumber(SortingCodeAccountValidationRequest request);
    }
}
