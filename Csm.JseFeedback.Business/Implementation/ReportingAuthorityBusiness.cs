using Csm.JseFeedback.Business.Contract;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Repository;
using Csm.JseFeedback.Repository.Contract;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business.Implementation
{
    public class ReportingAuthorityBusiness : BaseBusiness, IReportingAuthorityBusiness
    {
        private readonly IReportingAuthorityRepository _authorityRepository;
        public ReportingAuthorityBusiness(ILogger<BaseBusiness> logger, IReportingAuthorityRepository authorityRepository) : base(logger)
        {
            _authorityRepository = authorityRepository ?? throw new ArgumentNullException(nameof(authorityRepository));
        }

        public async Task<string> AddJseRa(JseRaDaoModel jseRa)
        {
            try
            {
                return await _authorityRepository.AddJseRa(jseRa);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in ReportingAuthorityBusiness.AddJseRA");
                throw;
            }
        }
        public async Task<string> UpdateJseRa(JseRaDaoModel jseRA)
        {
            try
            {
                return await _authorityRepository.UpdateJseRa(jseRA);
            }

            catch (Exception ex)
            {
                _logger.LogError("Exception in ReportingAuthorityBusiness.UpdateJseRA");
                throw;
            }
        }

        public async Task<string> DeleteReportingAuthority(JseRaDaoModel jseRA)
        {
            try
            {
                return await _authorityRepository.DeleteReportingAuthority(jseRA);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in ReportingAuthorityBusiness.DeleteRA");
                throw;
            }
        }

        public async Task<List<RaDaoModel>> GetJseRaDetails()
        {
            try
            {
                return await _authorityRepository.GetJseRaDetails();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingAuthorityBusiness.GetRa");
                throw;
            }
        }

        public async Task<string> CreateMapRAJse(JseUserRAMapModel jseMapRaUserModel)
        {
            try
            {
                return await _authorityRepository.CreateMapRAJse(jseMapRaUserModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in ReportingAuthorityMapRAInternBusiness.CreateMapRAJse");
                throw;
            }
        }

        public async Task<List<JseRAMapDaoDetailsModel>> GetJseMapRaInternsDetails()
        {
            try
            {
                return await _authorityRepository.GetJseMapRaInternsDetails();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingAuthorityBusiness.GetJseMapRaInternsDetails");
                throw;
            }
        }

        public async Task<string> DeleteMapRAIntern(JseUserRAMapDaoModel jseRAModel)
        {
            try
            {
                return await _authorityRepository.DeleteMapRAIntern(jseRAModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in ReportingAuthorityBusiness.DeleteMapRAInterns");
                throw;
            }
        }

        public async Task<string> UpdateMapRAIntern(JseUserRAMapDaoModel jseRAModel)
        {
            try
            {
                return await _authorityRepository.UpdateMapRAInternData(jseRAModel);
            }

            catch (Exception ex)
            {
                _logger.LogError("Exception in ReportingAuthorityBusiness.UpdateJseRA");
                throw;
            }
        }
    }
}
