using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository.Contract
{
    public interface IReportingAuthorityRepository
    {
        Task<string> AddJseRa(JseRaDaoModel jseRa);
        Task<string> UpdateJseRa(JseRaDaoModel jseUser);
        Task<string> DeleteReportingAuthority(JseRaDaoModel jseRA);
        Task<List<RaDaoModel>> GetJseRaDetails();
        Task<string> CreateMapRAJse(JseUserRAMapModel jseUserModel);
        Task<List<JseRAMapDaoDetailsModel>> GetJseMapRaInternsDetails();
        Task<string> DeleteMapRAIntern(JseUserRAMapDaoModel jseRAModel);
        Task<string> UpdateMapRAInternData(JseUserRAMapDaoModel jseRAModel);
    }
}
