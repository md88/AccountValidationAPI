using SortingCodeAccountValidationAPI.Domain.Enums;

namespace SortingCodeAccountValidationAPI.Domain.Model.Modulus.Responses
{
    /// <summary>
    /// A modulus weighting.
    /// </summary>
    public class ModulusWeighting : IDto
    {
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public int Start { get; set; }

        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public int End { get; set; }

        /// <summary>
        /// Gets or sets the mod check.
        /// </summary>
        /// <value>
        /// The mod check.
        /// </value>
        public ModCheck ModCheck { get; set; }

        /// <summary>
        /// Gets or sets the weights.
        /// </summary>
        /// <value>
        /// The weights.
        /// </value>
        public int[] Weights { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public int? Exception { get; set; }
    }
}