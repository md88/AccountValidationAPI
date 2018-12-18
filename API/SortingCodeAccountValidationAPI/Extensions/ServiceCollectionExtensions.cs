using Microsoft.Extensions.DependencyInjection;
using SortingCodeAccountValidationAPI.Domain.DependencyInjection;

namespace SortingCodeAccountValidationAPI.Extensions
{
    /// <summary>
    /// A collection of extension methods for use with <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the dependencies.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.Scan(sc => sc
                .FromApplicationDependencies()
                .AddClasses(c => c.AssignableTo<ITransientService>())
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}
