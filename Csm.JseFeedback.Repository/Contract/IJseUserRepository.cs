﻿using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public interface IJseUserRepository
    {
        //Task<IList<JseUserModel>> SearchJseList(JseSearchModel jseSearch);
        //Task<JseUserModel> GetJseDetails(JseSearchModel jseSearch);
        Task<string> AddJseInformation(JseUserDaoModel jseUser);
        Task<string> UpdateJseInformation(JseUserDaoModel jseUser);
        Task<string> DeleteJseInformation(JseUserDaoModel jseUser);
        //Task<bool> AddJseToBatch(JseUserModel jseUser);
    }
}
