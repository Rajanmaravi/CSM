using Csm.JseFeedback.Model;
using Csm.JseFeedback.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public class JseUserBusiness:BaseBusiness, IJseUserBusiness
    {
        private readonly IJseUserRepository _jseUserRepository;

        public JseUserBusiness(ILogger<BaseBusiness> logger, IJseUserRepository jseUserRepository) : base(logger)
        {
            _jseUserRepository = jseUserRepository?? throw new ArgumentNullException(nameof(jseUserRepository));
        }

        public async Task<string> AddJse(JseUserModel jseUser)
        {
            try
            {
                return await _jseUserRepository.AddJseInformation(jseUser);
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception in JseUserBusiness.AddJse");
                throw;
            }
        }

        public async Task<string> UpdateJse(JseUserModel jseUser)
        {
            try
            {
                return await _jseUserRepository.UpdateJseInformation(jseUser);
            }
            
            catch(Exception ex)
            {
                _logger.LogError("Exception in JseUserBusiness.UpdateJse");
                throw;
            }
}

        public async Task<string> DeleteJse(JseUserModel jseUser)
        {
            try
            {
                return await _jseUserRepository.DeleteJseInformation(jseUser);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in JseUserBusiness.DeleteJse");
                throw;
            }
        }

    }
}
