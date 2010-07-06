using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ant.Models
{
    public static class AjaxResult
    {
        public static ActionResult AjaxOK(this Controller control)
        {
            return Content("ok");
        }

        public static ActionResult AjaxError(this Controller control, string message)
        {
            return Content(string.Format("error:{0}", message));
        }

        public static ActionResult Ajax(this Controller control)
        {
            if (control.ModelState.IsValid)
            {
                return control.AjaxOK();
            }
            else
            {
                var msg = string.Join(";", control.ModelState.Values.Select(m => m.Value.AttemptedValue).ToArray());
                return control.AjaxError(msg);
            }
        }

        private static ActionResult Content(string msg)
        {
            return new ContentResult() { Content = msg };
        }
    }
}