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
     
    }
}
