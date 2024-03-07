using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Repository;
using Microsoft.AspNetCore.Http;
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

        public async Task<string> AddJse(JseUserAddDaoModel jseUser)
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

        public async Task<string> UpdateJse(JseUserDaoModel jseUser)
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

        public async Task<string> DeleteJse(JseUserDaoModel jseUser)
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

        public async Task<List<JseUserDaoDetailsModel>> GetJseUserDetails()
        {
            try
            {
                return await _jseUserRepository.GetJseUserDetails();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in JseUserBusiness.GetJseUserDetails");
                throw;
            }
        }

        public async Task<string> UploadJseData(IFormFile formFile)
        {
            return await _jseUserRepository.UploadJseData(formFile);
        }

        public async Task<List<JseUserDaoDetailsModel>> GetMapRAJseUserDetails()
        {
            try
            {
                return await _jseUserRepository.GetMapRAJseUserDetails();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in JseUserBusiness.GetMapRAJseUserDetails");
                throw;
            }
        }
    }
}
