using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public interface IJseFeedbackRemarkRepository
    {
        Task<string> AddJseFeedbackRemark(JseFeedbackModel jsefeedbackRemark);
        Task<string> UpdateJseFeedbackRemark(JseFeedbackModel jsefeedbackRemark);
        Task<string> DeleteJseFeedbackRemark(JseFeedbackModel jsefeedbackRemark);
    }
}
