﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.Author
{
  /// <summary>Provides a simple API to execute a task with an instance of the <see cref="AspNetPatchSample.Author.IAuthorEntity"/>.</summary>
  public interface IAuthorService : IService<IAuthorIdentity, IAuthorEntity>
  {
  }
}
