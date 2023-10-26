using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Repository;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public class UserBusiness :BaseBusiness, IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        public UserBusiness(ILogger<UserBusiness> logger, IUserRepository userRepository) :base(logger) 
        {
            _userRepository = userRepository;
        }

        public Task<string> AddUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangePassword(PasswordChangeModel passwordChange)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> SearchUser(UserSearchModel userSearch)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateRefreshToken(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> ValidateUser(LoginModel loginModel)
        {
            try
            {
                return await _userRepository.ValidateUser(loginModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserBusiness.ValidateUser");
                throw;
            }

        }
    }
}
