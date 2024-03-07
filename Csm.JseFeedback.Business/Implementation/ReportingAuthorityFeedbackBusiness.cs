using Csm.JseFeedback.Business.Contract;
using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Repository.Contract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business.Implementation
{
    public class ReportingAuthorityFeedbackBusiness : BaseBusiness, IReportingAuthorityFeedbackBusiness
    {
        
        private readonly IReportingAuthorityFeedbackRepository _authorityRepository;
        public ReportingAuthorityFeedbackBusiness(ILogger<BaseBusiness> logger, IReportingAuthorityFeedbackRepository authorityRepository) : base(logger)
        {
            _authorityRepository = authorityRepository ?? throw new ArgumentNullException(nameof(authorityRepository));
        }

        public async Task<string> AddRAFeedback(RAFeedbackModel rAFeedback)
        {
            try
            {
                return await _authorityRepository.AddRAFeedback(rAFeedback);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingAuthorityFeedbackBusiness.AddRAFeedback");
                throw;
            }
        }

        public async Task<List<RaFeedbackDaoDetailsModel>> GetRAFeedback(FeedbackByRaCodeDaoModel feedback)
        {
            try
            {
                return await _authorityRepository.GetRAFeedback(feedback); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingAuthorityFeedbackBusiness.GetRAFeedback");
                throw;
            }
        }
        public async Task<List<FeedbackByRaCodeDaoModel>> GetFeedbackByRaCode(string raCode)
        {
            try
            {
                return await _authorityRepository.GetFeedbackByRaCode(raCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingAuthorityFeedbackBusiness.GetFeedbackByRaCode");
                throw;
            }
        }

    }
}
