using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business.Contract
{
    public interface IReportingAuthorityBusiness
    {
        Task<string> AddJseRa(JseRaDaoModel jseRa);
        Task<string> UpdateJseRa(JseRaDaoModel jseRA);
        Task<string> DeleteReportingAuthority(JseRaDaoModel jseRA);
        Task<List<RaDaoModel>> GetJseRaDetails();
        Task<string> CreateMapRAJse(JseUserRAMapModel jseUserModel);
        Task<List<JseRAMapDaoDetailsModel>> GetJseMapRaInternsDetails();
        Task<string> DeleteMapRAIntern(JseUserRAMapDaoModel jseRAModel);
        Task<string> UpdateMapRAIntern(JseUserRAMapDaoModel jseRAModel);
    }
}
