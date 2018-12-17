using System;
using SortingCodeAccountValidationAPI.Domain.Model;
using SortingCodeAccountValidationAPI.Domain.Services;

namespace SortingCodeAccountValidationAPI.Services
{
    /// <inheritdoc />
    public class ValidationService : IValidationService
    {
        /// <inheritdoc />
        public IServiceResponse ValidateSortingCodeAndAccountNumber(SortingCodeAccountValidationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
