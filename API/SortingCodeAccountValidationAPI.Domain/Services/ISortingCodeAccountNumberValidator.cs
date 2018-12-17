using SortingCodeAccountValidationAPI.Domain.DependencyInjection;

namespace SortingCodeAccountValidationAPI.Domain.Services
{
    /// <summary>
    /// A sorting code / account number validator.
    /// </summary>
    public interface ISortingCodeAccountNumberValidator : ITransientService
    {
        /// <summary>
        /// Validates the specified sorting code and account number
        /// </summary>
        /// <param name="sortingCode">The sorting code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>Indication the sorting code / account number combination</returns>
        bool Validate(string sortingCode, int accountNumber);
    }
}
