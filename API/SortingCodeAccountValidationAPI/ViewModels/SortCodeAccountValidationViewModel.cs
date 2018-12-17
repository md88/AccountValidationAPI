using System.ComponentModel.DataAnnotations;

namespace SortingCodeAccountValidationAPI.ViewModels
{
    /// <summary>
    /// The Sorting Code / Account Validation View Model.
    /// </summary>
    public class SortCodeAccountValidationViewModel
    {
        /// <summary>
        /// Get or sets the Sorting code
        /// </summary>
        [Required]
        public string SortingCode { get; set; }

        /// <summary>
        /// Gets or sets the Account Number.
        /// </summary>
        [Required]
        public int AccountNumber { get; set; }
    }
}
