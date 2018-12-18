namespace SortingCodeAccountValidationAPI.Domain.Enums
{
    /// <summary>
    /// The modulus check enum.
    /// </summary>
    public enum ModCheck
    {
        /// <summary>
        /// The mod check to use has not been set.
        /// </summary>
        NotSpecified,

        /// <summary>
        /// The standard mod 10 check.
        /// </summary>
        MOD10,

        /// <summary>
        /// The standard mod 11 check.
        /// </summary>
        MOD11,

        /// <summary>
        /// The double alternative check.
        /// </summary>
        DBLAL,
    }
}
