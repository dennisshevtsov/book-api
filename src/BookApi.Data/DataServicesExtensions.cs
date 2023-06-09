﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using BookApi.Data;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>Extends the API of the <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>.</summary>
public static class DataServicesExtensions
{
  /// <summary>Sets up the infrastructure.</summary>
  /// <param name="services">An object that specifies the contract for a collection of service descriptors.</param>
  /// <param name="configuration">An object that represents a set of key/value application configuration properties.</param>
  /// <returns>An object that specifies the contract for a collection of service descriptors.</returns>
  public static IServiceCollection SetUpInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    services.AddRepositories();

    services.Configure<DatabaseOptions>(configuration);
    services.AddDbContext<DbContext, AppDbContext>((provider, builder) =>
    {
      DatabaseOptions options = provider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
      ArgumentException.ThrowIfNullOrEmpty(options.ConnectionString);

      builder.UseNpgsql(options.ConnectionString);
    });

    return services;
  }
}
