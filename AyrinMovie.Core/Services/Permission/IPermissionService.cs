using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AyrinMovie.Core.Services.Permission
{
    public interface IPermissionService
    {
        void AddRoleToUser(int roldId, int userId);
        void EditUserRole(int roldId, int userId);
        List<SelectListItem> GetRoles();
       bool CheckPermission(int permissionId, string email);
    }

}
