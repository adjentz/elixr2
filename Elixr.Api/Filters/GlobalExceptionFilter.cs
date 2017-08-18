using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Elixr2.Api.Filters
{
    class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ;
        }
    }
}