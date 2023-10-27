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

        public async Task<string> AddUser(UserModel userModel)
        {
            try
            {
                return await _userRepository.AddUser(userModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserBusiness.AddUser");
                throw;
            }
        }

        public async Task<string> ChangePassword(PasswordChangeModel passwordChange)
        {
            try
            {
                return await _userRepository.ChangePassword(passwordChange);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserBusiness.ChangePassword");
                throw;
            }
        }

        public async Task<string> DeleteUser(UserModel userModel)
        {
            try
            {
                return await _userRepository.DeleteUser(userModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserBusiness.DeleteUser");
                throw;
            }
        }

        public async Task<IEnumerable<UserModel>> SearchUser(UserSearchModel userSearch)
        {
            try
            {
                return await _userRepository.SearchUser(userSearch);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserBusiness.SearchUser");
                throw;
            }
        }

        public async Task<string> UpdateRefreshToken(UserModel userModel)
        {
            try
            {
                return await _userRepository.UpdateRefreshToken(userModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserBusiness.UpdateRefreshToken");
                throw;
            }
        }

        public async Task<string> UpdateUser(UserModel userModel)
        {
            try
            {
                return await _userRepository.UpdateUser(userModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserBusiness.UpdateRefreshToken");
                throw;
            }
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
