using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Microsoft.AspNetCore.Http;
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
        Task<string> AddJseInformation(JseUserAddDaoModel jseUser);
        Task<string> UpdateJseInformation(JseUserDaoModel jseUser);
        Task<string> DeleteJseInformation(JseUserDaoModel jseUser);
        //Task<bool> AddJseToBatch(JseUserModel jseUser);
        Task<List<JseUserDaoDetailsModel>> GetJseUserDetails();
        Task<string> UploadJseData(IFormFile formFile);
        Task<List<JseUserDaoDetailsModel>> GetMapRAJseUserDetails();
    }
}
