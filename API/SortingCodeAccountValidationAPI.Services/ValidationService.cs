using System;
using System.Collections.Generic;
using System.Linq;
using SortingCodeAccountValidationAPI.Domain.Model;
using SortingCodeAccountValidationAPI.Domain.Model.Modulus.Responses;
using SortingCodeAccountValidationAPI.Domain.Repositories;
using SortingCodeAccountValidationAPI.Domain.Services;
using SortingCodeAccountValidationAPI.Services.Model;

namespace SortingCodeAccountValidationAPI.Services
{
    /// <inheritdoc />
    public class ValidationService : IValidationService
    {
        /// <summary>
        /// The modulus weighting repository.
        /// </summary>
        private readonly IRepository<ModulusWeighting> modulusWeightingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationService"/> class.
        /// </summary>
        /// <param name="modulusWeightingRepository">The modulus weighting repository.</param>
        public ValidationService(IRepository<ModulusWeighting> modulusWeightingRepository)
        {
            this.modulusWeightingRepository = modulusWeightingRepository;
        }

        /// <inheritdoc />
        public IServiceResponse ValidateSortingCodeAndAccountNumber(Domain.Model.Requests.SortingCodeAccountValidationRequest request)
        {
            var response = new ServiceResponse();

            var weightings = this.GetWeightings(request.SortingCode);

            // If nothing found then return success.
            if (weightings == null || !weightings.Any())
            {
                response.Success = true;
                return response;
            }

            var implementedExceptions = new List<int> { 4, 7 };

            if (weightings.Any(o => o.Exception.HasValue && !implementedExceptions.Contains(o.Exception.Value)))
            {
                response.Message = "Weighting Exceptions not implemented for the provided sorting code";
                return response;
            }

            var combinationToValidate = string.Concat(request.SortingCode, request.AccountNumber);

            foreach (var weighting in weightings)
            {
                var weights = weighting.Weights;

                var calculatedValue = 0;
                int modVal = 0;

                switch (weighting.ModCheck)
                {
                    case Domain.Enums.ModCheck.MOD10:
                        {
                            for (var i = 0; i < weights.Length; i++)
                            {
                                calculatedValue += combinationToValidate[i] * weights[i];
                            }

                            modVal = calculatedValue % 10;

                            break;
                        }
                    case Domain.Enums.ModCheck.MOD11:
                        {
                            for (var i = 0; i < weights.Length; i++)
                            {
                                calculatedValue += combinationToValidate[i] * weights[i];
                            }

                            modVal = calculatedValue % 11;

                            break;
                        }
                    case Domain.Enums.ModCheck.DBLAL:
                        {
                            for (var i = 0; i < weights.Length; i++)
                            {
                                var val = combinationToValidate[i] * weights[i];

                                var splitVal = val.ToString().Sum(o => Convert.ToInt32(o.ToString()));

                                calculatedValue += splitVal;

                                modVal = calculatedValue % 10;
                            }

                            break;
                        }
                }
                
            }

            return response;
        }

        private IEnumerable<ModulusWeighting> GetWeightings(string sortingCode)
        {
            var code = this.ConvertSortingCodeToInteger(sortingCode);

            var weightings = this.modulusWeightingRepository
                .Where(o => o.Start <= code && o.End >= code)
                .ToList();

            return weightings;
        }

        private int? ConvertSortingCodeToInteger(string sortingCode)
        {
            int? convertedSortingCode = null;

            if (string.IsNullOrEmpty(sortingCode))
            {
                return convertedSortingCode;
            }

            convertedSortingCode = Convert.ToInt32(sortingCode.TrimStart(new Char[] { '0' }));

            return convertedSortingCode;
        }
    }
}
