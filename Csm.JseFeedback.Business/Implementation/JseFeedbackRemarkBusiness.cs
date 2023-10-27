using Csm.JseFeedback.Model;
using Csm.JseFeedback.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business 
{
    public class JseFeedbackRemarkBusiness : BaseBusiness, IJseFeedbackRemarkBusiness
    {
        private readonly IJseFeedbackRemarkRepository _jseFeedbackRemarkRepository;
        public JseFeedbackRemarkBusiness(ILogger<BaseBusiness> logger, IJseFeedbackRemarkRepository jseFeedbackRemarkRepository) : base(logger)
        {
            _jseFeedbackRemarkRepository = jseFeedbackRemarkRepository;

        }

        public async Task<string> AddJseFeedbackRemark(JseFeedbackModel jseFeedbackRemark)
        {
            return await _jseFeedbackRemarkRepository.AddJseFeedbackRemark(jseFeedbackRemark);
        }

        public async Task<string> UpdateJseFeedbackRemark(JseFeedbackModel jseFeedbackRemark)
        {
            return await _jseFeedbackRemarkRepository.UpdateJseFeedbackRemark(jseFeedbackRemark);
        }

        public async Task<string> DeleteJseFeedbackRemark(JseFeedbackModel jseFeedbackRemark)
        {
            return await _jseFeedbackRemarkRepository.DeleteJseFeedbackRemark(jseFeedbackRemark);
        }
    }
}
