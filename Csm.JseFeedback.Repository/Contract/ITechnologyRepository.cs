using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<TechnologyModel>> SearchTechnologies(TechnologySearchModel technologySearch);
        Task<TechnologyModel> GetTechnology(TechnologySearchModel technologySearch);
        Task<string> AddTechnology(TechnologyDaoModel technology);
        Task<string> UpdateTechnology(TechnologyDaoModel technology);
        Task<string> DeleteTechnology(TechnologyDaoModel technology);
        Task<List<TechnologyDetailsDaoModel>> GetTechnologyList();
    }
}
