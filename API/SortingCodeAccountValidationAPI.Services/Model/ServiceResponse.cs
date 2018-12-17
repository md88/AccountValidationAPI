using SortingCodeAccountValidationAPI.Domain.Model;

namespace SortingCodeAccountValidationAPI.Services.Model
{
    /// <summary>
    /// A service Response.
    /// </summary>
    public class ServiceResponse : IServiceResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ServiceResponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}
