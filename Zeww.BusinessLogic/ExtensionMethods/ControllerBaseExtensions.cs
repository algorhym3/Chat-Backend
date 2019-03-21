using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zeww.Models;

namespace Zeww.BusinessLogic.ExtensionMethods
{
    public static class ControllerExtensions
    {
        public static User GetAuthenticatedUser(this Controller controller)
        {
            return controller.Request.HttpContext.Items["user"] as User;
        }
    }
}
