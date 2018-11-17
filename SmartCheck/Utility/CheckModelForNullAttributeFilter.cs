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
    /// Model Validation Filter
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CheckModelForNullAttributeFilter : ActionFilterAttribute
    {
        /// <summary>
        /// The dictionary variable
        /// </summary>
        private readonly Func<Dictionary<string, object>, bool> _validate;
        /// <summary>
        /// Contructor
        /// </summary>
        public CheckModelForNullAttributeFilter() : this(arguments =>
                                        arguments.ContainsValue(null))
        { }
        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="checkCondition"></param>
        public CheckModelForNullAttributeFilter(Func<Dictionary<string, object>, bool> checkCondition)
        {
            _validate = checkCondition;
        }
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (_validate(actionContext.ActionArguments))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                                       HttpStatusCode.BadRequest, "ERROR");
            }
        }
    }
}