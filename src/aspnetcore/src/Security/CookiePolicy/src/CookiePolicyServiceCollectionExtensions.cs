// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for the cookie policy middleware.
    /// </summary>
    public static class CookiePolicyServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services and options for the cookie policy middleware.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> for adding services.</param>
        /// <param name="configureOptions">A delegate to configure the <see cref="CookiePolicyOptions"/>.</param>
        /// <returns></returns>
        public static IServiceCollection AddCookiePolicy(this IServiceCollection services, Action<CookiePolicyOptions> configureOptions)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            return services.Configure(configureOptions);
        }

        /// <summary>
        /// Adds services and options for the cookie policy middleware.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> for adding services.</param>
        /// <param name="configureOptions">A delegate to configure the <see cref="CookiePolicyOptions"/>.</param>
        /// <returns></returns>
        public static IServiceCollection AddCookiePolicy<TService>(this IServiceCollection services, Action<CookiePolicyOptions, TService> configureOptions) where TService : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            services.AddOptions<CookiePolicyOptions>().Configure(configureOptions);
            return services;
        }
    }
}
