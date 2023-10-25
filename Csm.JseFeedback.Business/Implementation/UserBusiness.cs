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
