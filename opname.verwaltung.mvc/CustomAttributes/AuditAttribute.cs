﻿using opname.verwaltung.Management.ApplicationServices.DataConnection.MongoDB;
using opname.verwaltung.Management.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace opname.verwaltung.mvc.CustomAttributes
{
    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;
            // Generate an audit
            AuditRecord audit = new AuditRecord()
            {
                // Your Audit Identifier     
                AuditID = Guid.NewGuid(),
                // Our Username (if available)
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                // The IP Address of the Request
                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                // The URL that was accessed
                AreaAccessed = request.RawUrl,
                // Creates our Timestamp
                Timestamp = DateTime.UtcNow
            };

            // Stores the Audit in the Database
            DataStorage context = new DataStorage();
            context.Record = audit;
            context.Insert();

            // Finishes executing the Action as normal 
            base.OnActionExecuting(filterContext);
        }
    }
}