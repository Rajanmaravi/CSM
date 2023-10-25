using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public interface IJseBusiness
    {
        Task<IList<JseUserModel>> SearchJseList(JseSearchModel jseSearch);
        Task<JseUserModel> GetJseDetails(JseSearchModel jseSearch);
        Task<bool> AddJse(JseUserModel jseUser);
        Task<bool> UpdateJse(JseUserModel jseUser);
        Task<bool> DeleteJse(int jseId);
        Task<bool> AddJseToBatch(JseUserModel jseUser);
    }
}
