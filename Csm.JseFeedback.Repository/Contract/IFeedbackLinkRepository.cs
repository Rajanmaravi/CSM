using Csm.JseFeedback.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository.Contract
{
    public interface IFeedbackLinkRepository
    {
        Task<string> SendLinkToRA(List<FeedbackLinkDaoModel> jseLinkModel);
    }
}
