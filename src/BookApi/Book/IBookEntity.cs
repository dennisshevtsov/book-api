﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using BookApi.Author;

namespace BookApi.Book;

/// <summary>Represents a book entity.</summary>
public interface IBookEntity : IBookIdentity
{
  /// <summary>Gets an object that represents a title of a book.</summary>
  public string Title { get; }

  /// <summary>Gets an object that represents a description of a book.</summary>
  public string Description { get; }

  /// <summary>Gets an object that represents a description of a book.</summary>
  public int Pages { get; }

  /// <summary>Gets an object that represents a collection of authors of this book.</summary>
  public IEnumerable<IAuthorEntity> Authors { get; }
}
