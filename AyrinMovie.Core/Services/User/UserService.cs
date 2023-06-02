using AyrinMovie.Core.Convertors;
using AyrinMovie.Core.DTOs.User;
using AyrinMovie.Core.Generator;
using AyrinMovie.Core.Services.Permission;
using AyrinMovie.DataLayer.Context;
using AyrinMovie.DataLayer.Entities.User;
using AyrinMovie.Core.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyrinMovie.Core.DTOs.AdminPanel;

namespace AyrinMovie.Core.Services
{
    public class UserService : IUserService
    {

        private readonly WebContext _context;

        public UserService(WebContext context, IPermissionService permissionService)
        {
            _context = context;
        }



        public int AddUser(CreateUserViewModel user)
        {
            User newUser = new User();

            #region Save Avatar


            if (user.UserAvatar != null)
            {
                // Main Image

                newUser.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(user.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/UserAvatar/", newUser.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }

                // Create Thumbnail

                string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/UserAvatar/Thumbnail/", newUser.UserAvatar);
                ImageConvertor.Image_Resize(imagePath, thumbnailPath, 150);

            }

            else
                newUser.UserAvatar = "Defult.jpg";


            #endregion

            newUser.FullName = user.FullName;
            newUser.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            newUser.ActiveCode = NameGenerator.GenerateUniqCode();
            newUser.Email = user.Email;
            newUser.PhoneNumber = user.PhoneNumber;
            newUser.Biography = user.Biography;

            // New Account is Active , Becuase We Create it From Admin Panel

            newUser.IsActive = true;
            newUser.RegisterDate = DateTime.Now;

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser.UserId;
        }


        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            user.isDeleted = true;
            _context.SaveChanges();
        }


        public int EditUser(EditUserViewModel editUser)
        {
            var user = GetUserByUserId(editUser.userId);

            user.FullName = editUser.FullName;
            user.Email = editUser.Email;
            user.PhoneNumber = editUser.PhoneNumber;
            user.Biography = editUser.Biography;


            if (!string.IsNullOrEmpty(editUser.Password))
            {
                user.Password = PasswordHelper.EncodePasswordMd5(editUser.Password);
            }


            if (editUser.UserAvatar != null)
            {

                // Delete Old Avatar
                DeleteUserAvatar(editUser.ImageName);

                #region Save New Avatar

                // Edit Main Image

                user.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(editUser.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/UserAvatar", user.UserAvatar);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUser.UserAvatar.CopyTo(stream);
                }

                // Edit Thumbnail

                string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/UserAvatar/Thumbnail", user.UserAvatar);
                ImageConvertor.Image_Resize(imagePath, thumbnailPath, 150);

                #endregion
            }

            UpdateUser(user);
            return user.UserId;
        }

        #region Get User

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserByUserId(int userId)
        {
            return _context.Users.Find(userId);
        }


        #endregion

        #region Check Exists

        public bool IsExistActiceCode(string activeCode)
        {
            return _context.Users.Any(u => u.ActiveCode == activeCode);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUser(int userId)
        {
            return _context.Users.Any(u => u.UserId == userId);
        }



        #endregion


        public EditUserViewModel GetUserForEditMode(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).Select(u => new EditUserViewModel()
            {
                userId = u.UserId,
                FullName = u.FullName,
                Email = u.Email,
                ImageName = u.UserAvatar,
                PhoneNumber = u.PhoneNumber,
                Biography = u.Biography,
                UserRole = _context.UserRoles.SingleOrDefault(r => r.UserId == u.UserId).RoleId

            }).Single();
        }



        public List<UserForShowInAdminPanelViewModel> GetUsers()
        {
            return _context.Users.Select(u => new UserForShowInAdminPanelViewModel()
            {
                userId = u.UserId,
                FullName = u.FullName,
                Biography = u.Biography,
                RegisterDate = u.RegisterDate,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                UserAvatar = u.UserAvatar,
                UserRole = _context.UserRoles.Single(r => r.UserId == u.UserId).RoleId

            }).ToList();
        }



        public User LoginUser(string email, string password)
        {
            string hashedPassword = PasswordHelper.EncodePasswordMd5(password);
            string fixedEmail = FixedText.FixEmail(email);
            return _context.Users.SingleOrDefault(u => u.Email == fixedEmail && u.Password == hashedPassword);
        }



        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public int GetIdByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email).UserId;
        }


        public bool IsGreatAdmin(User user)
        {
            var userId = user.UserId;
            return IsGraetAdmin(userId);
        }


        public bool IsGraetAdmin(int userId)
        {
            bool isGreatAdmin = false;

            List<int> UserRoles = _context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).ToList();
            List<int> GreatAdmins = _context.Roles.Where(r => r.isGreatAdmin).Select(r => r.RoleId).ToList();

            foreach (var item in GreatAdmins)
            {
                if (UserRoles.Contains(item))
                    isGreatAdmin = true;
            }

            return isGreatAdmin;
        }

        public string GetUserDescription(int userId)
        {
            return _context.Users.Find(userId).Biography;
        }

        public string GetUserAvatar(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email).UserAvatar;
        }

        public string GetUserAvatar(int userId)
        {
            return _context.Users.Find(userId).UserAvatar;
        }

        public void DeleteUserAvatar(string image)
        {
            if (image != "Defult.jpg")
            {
                string mainImageDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/UserAvatar", image);
                string thumbnailDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/UserAvatar/Thumbnail", image);

                if (File.Exists(mainImageDeletePath))
                    File.Delete(mainImageDeletePath);

                if (File.Exists(thumbnailDeletePath))
                    File.Delete(thumbnailDeletePath);
            }
        }




    }


}
