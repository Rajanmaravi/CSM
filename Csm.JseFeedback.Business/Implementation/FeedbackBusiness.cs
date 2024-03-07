using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Model.Search;
using Csm.JseFeedback.Repository;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public class FeedbackBusiness :BaseBusiness, IFeedbackBusiness
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackBusiness(ILogger<FeedbackBusiness> logger,IFeedbackRepository feedbackRepository):base(logger) 
        {
            _feedbackRepository = feedbackRepository??throw new ArgumentNullException(nameof(feedbackRepository));
        }

        public async Task<string> AddFeedback(FeedbackDaoModel feedback)
        {
            try
            {
                return await _feedbackRepository.AddFeedback(feedback); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackBusiness.AddFeedback");
                throw;
            }
        }

        public async Task<string> DeleteFeedback(FeedbackDaoModel feedback)
        {
            try
            {
                return await _feedbackRepository.DeleteFeedback(feedback);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackBusiness.DeleteFeedback");
                throw;
            }
        }

        public async Task<FeedbackModel> GetFeedback(FeedbackSearchModel feedbackSearch)
        {
            try
            {
                return await _feedbackRepository.GetFeedback(feedbackSearch);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackBusiness.GetFeedback");
                throw;
            }
        }    

        public async Task<IEnumerable<FeedbackModel>> SearchFeedbacks(FeedbackSearchModel feedbackSearch)
        {
            try
            {
                return await _feedbackRepository.SearchFeedbacks(feedbackSearch);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackBusiness.SearchFeedbacks");
                throw;
            }
        }

        public async Task<string> UpdateFeedback(FeedbackDaoModel feedback)
        {
            try
            {
                return await _feedbackRepository.UpdateFeedback(feedback);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackBusiness.UpdateFeedback");
                throw;
            }
        }

        public async Task<JseUserDaoDetailsModel> GetMapRAJseUserDetailsByCode(string internCode)
        {
            try
            {
                return await _feedbackRepository.GetMapRAUserDetailsByCode(internCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackBusiness.GetMapRAUserDetailsByCode");
                throw;
            }
        }

        public async Task<List<AspectDaoModel>> GetAspectDetails()
        {
            try
            {
                return await _feedbackRepository.GetAspectDetails();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackBusiness.GetAspectDetails");
                throw;
            }
        }
    }
}
