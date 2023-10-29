using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public interface IJseUserBusiness
    {
        //Task<IList<JseUserModel>> SearchJseList(JseSearchModel jseSearch);
        //Task<JseUserModel> GetJseDetails(JseSearchModel jseSearch);
        Task<string> AddJse(JseUserModel jseUser);
        Task<string> UpdateJse(JseUserModel jseUser);
        Task<string> DeleteJse(JseUserModel jseUser);
        //Task<bool> AddJseToBatch(JseUserModel jseUser);
    }
}
