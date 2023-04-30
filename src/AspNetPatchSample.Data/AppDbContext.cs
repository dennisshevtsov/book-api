﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Data
{
  using Microsoft.EntityFrameworkCore;

  using AspNetPatchSample.Author.Data;
  using AspNetPatchSample.Book.Data;

  /// <summary>Represents a session with the database and can be used to query and save instances of your entities.</summary>
  public sealed class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>Configures the model.</summary>
    /// <param name="modelBuilder">An object provides a simple API surface for configuring a <see cref="Microsoft.EntityFrameworkCore.Metadata.IMutableModel" />.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
      modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
    }
  }
}
