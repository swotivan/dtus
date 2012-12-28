using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace dtus.classes.webcontrol
{
    public class LoginControl : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;

            context.Response.Write("Welcome to DTUS");
        }
    }
}
