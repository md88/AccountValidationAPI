namespace SortingCodeAccountValidationAPI.Domain.Model
{
    /// <summary>
    /// A service Response.
    /// </summary>
    public interface IServiceResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ServiceResponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }
    }
}
