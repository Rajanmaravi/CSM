using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Microsoft.AspNetCore.Http;
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
        Task<string> AddJse(JseUserAddDaoModel jseUser);
        Task<string> UpdateJse(JseUserDaoModel jseUser);
        Task<string> DeleteJse(JseUserDaoModel jseUser);
        //Task<bool> AddJseToBatch(JseUserModel jseUser);
        Task<List<JseUserDaoDetailsModel>> GetJseUserDetails();
        Task<string> UploadJseData(IFormFile formFile);
        Task<List<JseUserDaoDetailsModel>> GetMapRAJseUserDetails();        

    }
}
