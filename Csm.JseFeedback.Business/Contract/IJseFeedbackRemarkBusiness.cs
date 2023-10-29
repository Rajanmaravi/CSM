using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public interface IJseFeedbackRemarkBusiness
    {
        Task<string> AddJseFeedbackRemark(JseDaoModel jsefeedback);
        Task<string> UpdateJseFeedbackRemark(JseDaoModel jsefeedback);
        Task<string> DeleteJseFeedbackRemark(JseDaoModel jsefeedback);
    }
}
