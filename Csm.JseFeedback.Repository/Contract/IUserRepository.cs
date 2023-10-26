using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public interface IUserRepository
    {
        Task<UserModel> ValidateUser(LoginModel loginModel);
        Task<string> AddUser(UserModel userModel);
        Task<string> UpdateUser(UserModel userModel);
        Task<string> DeleteUser(UserModel userModel);
        Task<IEnumerable<UserModel>> SearchUser(UserSearchModel userSearch);
        Task<string> ChangePassword(PasswordChangeModel passwordChange);
        Task<string> UpdateRefreshToken(UserModel userModel);


    }
}
