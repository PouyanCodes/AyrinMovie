using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.DTOs.User;
using AyrinMovie.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.Core.Services
{
    public interface IUserService
    {
        int AddUser(CreateUserViewModel user);
        void UpdateUser(User user);

        List<UserForShowInAdminPanelViewModel> GetUsers();
        User LoginUser(string username, string password);

        #region Get User

        User GetUserByUserId(int userId);
        User GetUserByEmail(string email);
        User GetUserByActiveCode(string activeCode);

        #endregion

        #region Check Exists

        bool IsExistEmail(string email);
        bool IsExistActiceCode(string activeCode);
        bool IsExistUser(int userId);

        #endregion

        int GetIdByEmail(string email);
        int EditUser(EditUserViewModel editUser);
        EditUserViewModel GetUserForEditMode(int userId);
        void DeleteUser(int userId);
        bool IsGreatAdmin(User user);
        bool IsGraetAdmin(int userId);
        string GetUserDescription(int userId);
        string GetUserAvatar(string email);
        string GetUserAvatar(int userId);
        void DeleteUserAvatar(string image);

    }
}
