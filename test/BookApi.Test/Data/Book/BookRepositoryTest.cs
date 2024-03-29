﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.Extensions.DependencyInjection;

using BookApi.Author;
using BookApi.Author.Data.Test;
using BookApi.Data.Test;

namespace BookApi.Book.Data.Test;

[TestClass]
public sealed class BookRepositoryTest : DataTestBase
{
#pragma warning disable CS8618
  private IBookRepository _bookRepository;
#pragma warning restore CS8618

  protected override void Initialize(IServiceProvider provider)
  {
    _bookRepository = provider.GetRequiredService<IBookRepository>();
  }

  [TestMethod]
  public async Task GetAsync_ExistingBookIdPassed_BookReturned()
  {
    // Arrange
    IBookEntity controlBookEntity = await TestBookEntity.AddAsync(DbContext);
    string[] relations = new[]
    {
      nameof(IBookEntity.Authors),
    };

    // Act
    IBookEntity? actualBookEntity  = await _bookRepository.GetAsync(controlBookEntity, relations, CancellationToken.None);

    // Assert
    Assert.IsNotNull(actualBookEntity);
    TestBookEntity.AreEqual(controlBookEntity, actualBookEntity);
  }

  [TestMethod]
  public async Task GetAsync_UknownBookIdPassed_NullReturned()
  {
    // Arrange
    IBookIdentity controlBookIdentity = TestBookIdentity.New();
    string[] relations = new[]
    {
      nameof(IBookEntity.Authors),
    };

    // Act
    IBookEntity? actualBookEntity = await _bookRepository.GetAsync(controlBookIdentity, relations, CancellationToken.None);

    // Assert
    Assert.IsNull(actualBookEntity);
  }

  [TestMethod]
  public async Task AddAsync_BookPassed_BookReturned()
  {
    // Arrange
    IBookEntity controlBookEntity = TestBookEntity.New();

    // Act
    IBookEntity actualBookEntity = await _bookRepository.AddAsync(controlBookEntity, CancellationToken.None);

    // Assert
    Assert.IsNotNull(actualBookEntity);
    TestBookEntity.AreEqual(controlBookEntity, actualBookEntity);
  }

  [TestMethod]
  public async Task AddAsync_BookPassed_BookSaved()
  {
    // Arrange
    IBookEntity controlBookEntity = TestBookEntity.New();

    // Act
    IBookEntity addedBookEntity   = await _bookRepository.AddAsync(controlBookEntity, CancellationToken.None);
    IBookEntity? actualBookEntity = await TestBookEntity.GetAsync(DbContext, addedBookEntity);

    // Assert
    Assert.IsNotNull(actualBookEntity);
    TestBookEntity.AreEqual(controlBookEntity, actualBookEntity);
  }

  [TestMethod]
  public async Task UpdateAsync_BookPassed_BookSaved()
  {
    // Arrange
    IList<IAuthorEntity> controlAuthorEntityCollection = await TestAuthorEntity.AddAsync(DbContext, 5);

    IAuthorEntity[] originalAuthorEntityCollection = controlAuthorEntityCollection.Take(2).ToArray();
    IBookEntity originalBookEntity = await TestBookEntity.AddAsync(DbContext, 500, originalAuthorEntityCollection);

    IAuthorEntity[] newAuthorEntityCollection = new[]
    {
      controlAuthorEntityCollection[0],
      controlAuthorEntityCollection[2],
      controlAuthorEntityCollection[3],
      controlAuthorEntityCollection[4],
    };
    IBookEntity newBookEntity  = TestBookEntity.New(800, newAuthorEntityCollection);
    string[] updatedProperties = new[]
    {
      nameof(IBookEntity.Title),
      nameof(IBookEntity.Description),
      nameof(IBookEntity.Pages),
      nameof(IBookEntity.Authors),
    };

    // Act
    await _bookRepository.UpdateAsync(originalBookEntity, newBookEntity, updatedProperties, CancellationToken.None);

    // Assert
    IBookEntity? actualBookEntity = await TestBookEntity.GetAsync(DbContext, originalBookEntity);

    Assert.IsNotNull(actualBookEntity);
    TestBookEntity.AreEqual(newBookEntity, actualBookEntity);
  }

  [TestMethod]
  public async Task DeleteAsync_ExistingBookPassed_BookDeleted()
  {
    // Arrange
    IBookEntity controlBookEntity = await TestBookEntity.AddAsync(DbContext);

    // Act
    await _bookRepository.DeleteAsync(controlBookEntity, CancellationToken.None);

    // Assert
    IBookEntity? actualBookEntity = await TestBookEntity.GetAsync(DbContext, controlBookEntity);
    Assert.IsNull(actualBookEntity);
  }

  [TestMethod]
  public async Task DeleteAsync_UnknownBookPassed_ExistingBookKept()
  {
    // Arrange
    IBookEntity controlBookEntity = await TestBookEntity.AddAsync(DbContext);
    IBookEntity unknownBookIdentity = TestBookEntity.New();

    // Act
    await _bookRepository.DeleteAsync(unknownBookIdentity, CancellationToken.None);

    // Assert
    IBookEntity? actualBookEntity = await TestBookEntity.GetAsync(DbContext, controlBookEntity);
    Assert.IsNotNull(actualBookEntity);
  }
}
