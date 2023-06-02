using AyrinMovie.DataLayer.Context;
using AyrinMovie.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.Core.Services.Permission
{
    public class PermissionService : IPermissionService
    {

        private readonly WebContext _context;
        
        public PermissionService(WebContext context)
        {
            _context = context;
            
        }

        public void AddRoleToUser(int roldId, int userId)
        {
            _context.UserRoles.Add(new UserRole()
            {
                RoleId = roldId,
                UserId = userId
            });

            _context.SaveChanges();
        }


        public void EditUserRole(int roldId, int userId)
        {
            var UserRole = _context.UserRoles.SingleOrDefault(u => u.UserId == userId);
            UserRole.RoleId = roldId;
            _context.SaveChanges();
        }


        public List<SelectListItem> GetRoles()
        {
            return _context.Roles.Where(r => !r.isGreatAdmin).Select(r => new SelectListItem()
            {
                Value = r.RoleId.ToString(),
                Text = r.RoleTitle

            }).ToList();

        }


        public bool CheckPermission(int permissionId, string email)
        {
            int userId = _context.Users.SingleOrDefault(u => u.Email == email).UserId;

            List<int> UserRoles = _context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).ToList();

            if (!UserRoles.Any())
                return false;

            List<int> RolesPermission = _context.RolePermissions
                .Where(p => p.PermissionId == permissionId)
                .Select(p => p.RoleId).ToList();

            return RolesPermission.Any(p => UserRoles.Contains(p));

        }



    }

}
