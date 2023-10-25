using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<FeedbackModel>> SearchFeedbacks(FeedbackSearchModel feedbackSearch);
        Task<FeedbackModel> GetFeedback(FeedbackSearchModel feedbackSearch);
        Task<string> AddFeedback(FeedbackModel feedback);
        Task<string> UpdateFeedback(FeedbackModel feedback);
        Task<string> DeleteFeedback(FeedbackModel feedbackModel);
        
    }
}
