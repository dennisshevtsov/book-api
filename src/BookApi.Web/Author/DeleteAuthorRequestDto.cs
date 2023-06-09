﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using BookApi.Web;

namespace BookApi.Author.Web;

/// <summary>Represents the DELETE author request data.</summary>
public sealed class DeleteAuthorRequestDto : IRequestDto, IAuthorIdentity
{
  /// <summary>Gets an objecct that represents an ID of an author.</summary>
  public Guid AuthorId { get; set; }
}
