using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SmartChef.Utility
{
    /// <inheritdoc />
    /// <summary>
    /// Validtes the Model in the request
    /// </summary>
    public class ValidateModelStateAttributeFilter : ActionFilterAttribute
    {
        /// <inheritdoc />
        /// <summary>
        /// Validates the Model
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}