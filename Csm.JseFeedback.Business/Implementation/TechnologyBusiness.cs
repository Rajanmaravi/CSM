using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Search;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public class TechnologyBusiness :BaseBusiness, ITechnologyBusiness
    {
        private ITechnologyRepository _technologyRepository;
        public TechnologyBusiness(ILogger<TechnologyBusiness> logger,ITechnologyRepository technologyRepository):base(logger) { _technologyRepository = technologyRepository??throw new ArgumentNullException(nameof(technologyRepository)); }

        public async Task<string> AddTechnology(TechnologyModel technology)
        {
            try
            {
                return await _technologyRepository.AddTechnology(technology);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyBusiness.AddTechnology");
                throw;
            }
        }

        public async Task<string> DeleteTechnology(TechnologyModel technology)
        {
            try
            {
                return await _technologyRepository.DeleteTechnology(technology);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyBusiness.DeleteTechnology");
                throw;
            }
        }

        public async Task<TechnologyModel> GetTechnology(TechnologySearchModel technologySearch)
        {
            try
            {
                return await _technologyRepository.GetTechnology(technologySearch);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyBusiness.GetTechnology");
                throw;
            }
        }

        public async Task<IEnumerable<TechnologyModel>> SearchTechnologies(TechnologySearchModel technologySearch)
        {
            try
            {
                return await _technologyRepository.SearchTechnologies(technologySearch);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyBusiness.SearchTechnologies");
                throw;
            }
        }

        public async Task<string> UpdateTechnology(TechnologyModel technology)
        {
            try
            {
                return await _technologyRepository.UpdateTechnology(technology);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyBusiness.UpdateTechnology");
                throw;
            }
        }
    }
}
