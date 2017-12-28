using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;
using Elixr2.Api.Models;
using Elixr2.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Elixr2.Api.Filters
{
    class AuthenticationFilter : Microsoft.AspNetCore.Mvc.Filters.IActionFilter
    {
        private readonly TokenSigner tokenSigner;
        private readonly UserSession userSession;
        public AuthenticationFilter(TokenSigner tokenSigner, UserSession userSession)
        {
            this.tokenSigner = tokenSigner;
            this.userSession = userSession;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if(controllerActionDescriptor == null)
            {
                return;
            }
            if(!controllerActionDescriptor.MethodInfo.GetCustomAttributes(true).Any(a => a.GetType() == typeof(AuthorizeFilter)))
            {
                return;
            }

            string tokenString = context.HttpContext.Request.Headers["X-ElixrToken"].FirstOrDefault();
            if(string.IsNullOrWhiteSpace(tokenString))
            {
                context.Result = new JsonResult(new { friendlyMessage = "Must be logged in"})
                {
                    StatusCode = 403
                };
                return;
            }
            if(!tokenString.StartsWith("{"))
            {
                var tokenBytes = Convert.FromBase64String(tokenString);
                tokenString = System.Text.Encoding.UTF8.GetString(tokenBytes);
            }

            var token = AuthToken.FromJson(tokenString);
            var statusCheck = tokenSigner.ValidateToken(token);

            if(!statusCheck.valid)
            {
                context.Result = new JsonResult(new { friendlyMessage = statusCheck.message})
                {
                    StatusCode = 403
                };
                return;
            }
            userSession.GamerId = token.GamerId;
            userSession.GamerName = token.GamerName;
        }
    }
}