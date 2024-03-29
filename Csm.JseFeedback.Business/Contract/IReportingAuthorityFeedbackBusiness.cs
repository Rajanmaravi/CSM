﻿using Csm.JseFeedback.Model.Dao;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business.Contract
{
    public interface IReportingAuthorityFeedbackBusiness
    {
        Task<string> AddRAFeedback(RAFeedbackModel rAFeedback);
        Task<List<RaFeedbackDaoDetailsModel>> GetRAFeedback(FeedbackByRaCodeDaoModel feedback);
        Task<List<FeedbackByRaCodeDaoModel>> GetFeedbackByRaCode(string raCode);
    }
}
