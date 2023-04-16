﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace AspNetPatchSample.WebApi.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  /// <summary>Provides a simple API to handle HTTP request.</summary>
  [ApiController]
  [Route("api/book")]
  [Produces("application/json")]
  public sealed class BookController : ControllerBase
  {
  }
}
