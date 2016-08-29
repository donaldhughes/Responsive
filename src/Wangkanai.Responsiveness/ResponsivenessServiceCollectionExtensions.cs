﻿// Copyright (c) 2016 Sarin Na Wangkanai, All Rights Reserved.
// The GNU GPLv3. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Wangkanai.Responsiveness;
using Wangkanai.Responsiveness.Abstractions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// ASP.NET Core middleware for routing to specific area base client request device
    /// Extension method for setting up Universal in an <see cref="IServiceCollection" />
    /// </summary>
    public static class ResponsivenessServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services required for application responsiveness.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddResponsiveness(
            this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddOptions();

            AddResponsivenessServices(services);

            return services;
        }

        ///// <summary>
        ///// Adds services required for application responsiveness.
        ///// </summary>
        ///// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        ///// <param name="setupAction">
        ///// An <see cref="Action{ResponsivenessOptions}"/> to configure the <see cref="ResponsivenessOptions"/></param>
        ///// <returns>The <see cref="IServiceCollection"/> sa that addidtional call be chained.</returns>
        //public static IServiceCollection AddResponsiveness(
        //    this IServiceCollection services,
        //    Action<ResponsivenessOptions> setupAction)
        //{
        //    if (services == null) throw new ArgumentNullException(nameof(services));
        //    if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

        //    AddResponsivenessServices(services, setupAction);

        //    return services;
        //}

        internal static void AddResponsivenessServices(
            IServiceCollection services)
        {
            services.TryAddSingleton<IResponsivenessFactory, ResponsivenessFactory>();
            services.TryAddTransient(typeof(IResponsivenessResolver),typeof(ResponsivenessResolver));
        }

        //internal static void AddResponsivenessServices(
        //    IServiceCollection services,
        //    Action<ResponsivenessOptions> setAction)
        //{
        //    AddResponsivenessServices(services);
        //    services.Configure(setAction);
        //}
    }
}
