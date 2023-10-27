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
        Task<string> AddJseFeedbackRemark(JseFeedbackModel jsefeedback);
        Task<string> UpdateJseFeedbackRemark(JseFeedbackModel jsefeedback);
        Task<string> DeleteJseFeedbackRemark(JseFeedbackModel jsefeedback);
    }
}
