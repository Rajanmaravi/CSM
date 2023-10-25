using Csm.JseFeedback.Model;
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
        Task<string> AddTechnology(TechnologyModel technology);
        Task<string> UpdateTechnology(TechnologyModel technology);
        Task<string> DeleteTechnology(TechnologyModel technology);
    }
}
