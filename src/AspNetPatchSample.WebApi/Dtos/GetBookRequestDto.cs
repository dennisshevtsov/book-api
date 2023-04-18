﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.WebApi.Dtos
{
  using Microsoft.AspNetCore.Mvc;

  using AspNetPatchSample.Domain.Entity;

  /// <summary>Represents a condition to query a book.</summary>
  public sealed class GetBookRequestDto : IBookIdentity
  {
    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.WebApi.Dtos.GetBookRequestDto"/> class.</summary>
    public GetBookRequestDto() { }

    /// <summary>Initializes a new instance of the <see cref="AspNetPatchSample.WebApi.Dtos.GetBookRequestDto"/> class.</summary>
    /// <param name="bookIdentity">An object that represents an identity of a book.</param>
    public GetBookRequestDto(IBookIdentity bookIdentity)
    {
      BookId = bookIdentity.BookId;
    }

    /// <summary>Gets an object that represents an ID of a book.</summary>
    [FromRoute]
    public Guid BookId { get; }
  }
}