using Csm.JseFeedback.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business.Contract
{
    public interface IFeedbackLinkBusiness
    {
        Task<string> SendLinkToRA(List<FeedbackLinkDaoModel> jseLinkModel);
    }
}
