using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public interface IUserBusiness
    {
        Task<UserModel> ValidateUser(LoginModel loginModel);
        Task<string> AddUser(UserDaoModel userModel);
        Task<string> UpdateUser(UserDaoModel userModel);
        Task<string> DeleteUser(UserDaoModel userModel);
        Task<IEnumerable<UserModel>> SearchUser(UserSearchModel userSearch);
        Task<string> ChangePassword(PasswordChangeModel passwordChange);
        Task<string> UpdateRefreshToken(UserDaoModel userModel);
        Task<UserModel> GetRoleByEmployeeCode(string employeeCode);
    }
}
