using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApp.Infrastructure.Middleware
{
    public class ErrorHandlingWiddleware
    {
        private readonly RequestDelegate _Next;
        private readonly ILogger<ErrorHandlingWiddleware> _Logger;

        public ErrorHandlingWiddleware(RequestDelegate Next, ILogger<ErrorHandlingWiddleware> Logger)
        {
            _Next = Next;
            _Logger = Logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _Next(context);
            }
            catch (Exception error)
            {
                HandleException(context, error);
                throw;
            }
        }

        private void HandleException(HttpContext context, Exception error)
        {
            _Logger.LogError(error, "Ошибка при обработке запроса {0}", context.Request.Path);
        }
    }
}
