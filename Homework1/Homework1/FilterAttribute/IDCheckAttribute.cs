using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Homework1.FilterAttribute
{
    public class IDCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters.Keys.Contains("id"))
            {
                var Id = filterContext.ActionParameters["id"] == null ? string.Empty : filterContext.ActionParameters["id"].ToString();
                Regex regex = new Regex(@"\d+");
                if (!regex.IsMatch(Id))
                {
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "IdError"
                    };
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}