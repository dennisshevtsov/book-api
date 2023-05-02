﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Book.Web
{
  using System.ComponentModel.DataAnnotations;

  /// <summary>Represents data to update a book.</summary>
  public sealed class PutBookRequestDto : BookRequestDtoBase, IBookEntity
  {
    /// <summary>Initalizes a new instance of the <see cref="AspNetPatchSample.Web.Dtos.PutBookRequestDto"/> class.</summary>
    public PutBookRequestDto() : base()
    {
      Title       = string.Empty;
      Author      = string.Empty;
      Description = string.Empty;
    }

    /// <summary>Gets an object that represents a title of a book.</summary>
    [Required]
    public string Title { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    public string Author { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    public string Description { get; set; }

    /// <summary>Gets an object that represents a description of a book.</summary>
    [Required]
    public int Pages { get; set; }
  }
}
