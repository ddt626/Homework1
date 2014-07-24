using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework1.Controllers
{
    public class BassController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            if (this.ControllerContext.HttpContext.Request.HttpMethod.ToUpper() == "GET")
            {
                this.View("My404Error").ExecuteResult(this.ControllerContext);
            }
            else
            {
                base.HandleUnknownAction(actionName);
            }
        }
    }
}