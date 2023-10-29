using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public interface ITechnologyBusiness
    {
        Task<IEnumerable<TechnologyModel>> SearchTechnologies(TechnologySearchModel technologySearch);
        Task<TechnologyModel> GetTechnology(TechnologySearchModel technologySearch);
        Task<string> AddTechnology(TechnologyDaoModel technology);
        Task<string> UpdateTechnology(TechnologyDaoModel technology);
        Task<string> DeleteTechnology(TechnologyDaoModel technology);
    }
}
