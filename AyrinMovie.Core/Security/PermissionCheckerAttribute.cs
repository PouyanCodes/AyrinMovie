using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Permission;

namespace AyrinMovie.Core.Security
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {

        private IPermissionService _permissionsService;
        private int _permissionId = 0;


        public PermissionCheckerAttribute(int permissionId)
        {
            _permissionId = permissionId;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permissionsService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string email = context.HttpContext.User.Identity.Name;

                if (!_permissionsService.CheckPermission(_permissionId,email))
                    context.Result = new RedirectResult("/Admin/Inaccessible");
            }
            else
            {
                context.Result = new RedirectResult("/Account/Login");
            }
        }





    }
}
