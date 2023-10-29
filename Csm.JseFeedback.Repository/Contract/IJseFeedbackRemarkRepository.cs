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
        Task<string> AddJseFeedbackRemark(JseDaoModel jsefeedbackRemark);
        Task<string> UpdateJseFeedbackRemark(JseDaoModel jsefeedbackRemark);
        Task<string> DeleteJseFeedbackRemark(JseDaoModel jsefeedbackRemark);
    }
}
