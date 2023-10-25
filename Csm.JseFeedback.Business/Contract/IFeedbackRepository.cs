using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public interface IFeedbackBusiness
    {
        Task<IEnumerable<FeedbackModel>> SearchFeedbacks(FeedbackSearchModel feedbackSearch);
        Task<FeedbackModel> GetFeedback(FeedbackSearchModel feedbackSearch);
        Task<string> AddFeedback(FeedbackModel feedback);
        Task<string> UpdateFeedback(FeedbackModel feedback);
        Task<string> DeleteFeedback(FeedbackModel feedbackModel);
        
    }
}
