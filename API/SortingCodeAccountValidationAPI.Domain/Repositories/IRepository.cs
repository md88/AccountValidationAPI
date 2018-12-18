using SortingCodeAccountValidationAPI.Domain.DependencyInjection;
using SortingCodeAccountValidationAPI.Domain.Model;
using System;
using System.Collections.Generic;

namespace SortingCodeAccountValidationAPI.Domain.Repositories
{
    /// <summary>
    /// A data repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : ITransientService
        where T : IDto
    {
        /// <summary>
        /// Returns list of <typeparamref name="T"/> that match <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>A list of <typeparamref name="T"/>.</returns>
        IEnumerable<T> Where(Func<T, bool> predicate);
    }
}
