namespace SortingCodeAccountValidationAPI.Domain.Model
{
    /// <summary>
    /// The sorting code / account number validation request.
    /// </summary>
    public class SortingCodeAccountValidationRequest
    {
        /// <summary>
        /// Gets or sets the sorting code.
        /// </summary>
        public string SortingCode { get; set; }
        
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        public int AccountNumber { get; set; }
    }
}
