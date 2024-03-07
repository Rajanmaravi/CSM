using Csm.JseFeedback.Business.Contract;
using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Repository;
using Csm.JseFeedback.Repository.Contract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business.Implementation
{
    public class FeedbackLinkBusiness : BaseBusiness, IFeedbackLinkBusiness
    {
        private readonly IFeedbackLinkRepository _feedbackLinkRepository;
        public FeedbackLinkBusiness(ILogger<FeedbackLinkBusiness> logger, IFeedbackLinkRepository feedbackLinkRepository) : base(logger)
        {
            _feedbackLinkRepository = feedbackLinkRepository ?? throw new ArgumentNullException(nameof(feedbackLinkRepository));
        }
        public async Task<string> SendLinkToRA(List<FeedbackLinkDaoModel> jseLinkModel)
        {
            try
            {
                return await _feedbackLinkRepository.SendLinkToRA(jseLinkModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackBusiness.AddFeedback");
                throw;
            }
        }
    }
}
