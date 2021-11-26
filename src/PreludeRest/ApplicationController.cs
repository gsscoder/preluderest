using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpX;

namespace PreludeRest
{
    public abstract class ApplicationController : ControllerBase
    {
        readonly ILogger _logger;

        public ApplicationController(ILogger logger)
        {
            _logger = logger;
        }

        protected IActionResult Result<TDto, TModel>(Maybe<TDto> maybe,
            Func<TDto, TModel> mapper, string notFoundMessage = null,
            IActionResult nothingResult = null)
        {
            switch (maybe.MatchJust(out var result)) {
                default:
                    return new OkObjectResult(mapper(result));
                case false:
                    if (nothingResult != null) return nothingResult;
                    if (notFoundMessage == null) return new NotFoundResult();
                    return new NotFoundObjectResult(new ErrorResult
                    {
                        Title = notFoundMessage
                    });

            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected OkObjectResult Result<TDto, TModel>(IEnumerable<TDto> sequence,
            Func<IEnumerable<TDto>, TModel> mapper) =>
            new OkObjectResult(mapper(sequence));

        protected ObjectResult Problem(string message)
        {
            _logger.LogCritical(message);
            return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
            {
                Type = ErrorType.Error500InternalServerError,
                Title = message,
                Status = StatusCodes.Status500InternalServerError
            });
        }

        protected BadRequestObjectResult BadRequest(string message)
        {
            _logger.LogError(message);
            return new BadRequestObjectResult(new ErrorResult
            {
                Type = ErrorType.Error400BadRequest,
                Title = message,
                Status = StatusCodes.Status400BadRequest
            });
        }
    }
}
