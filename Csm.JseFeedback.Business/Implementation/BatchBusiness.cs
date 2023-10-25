using Csm.JseFeedback.Model;
using Csm.JseFeedback.Repository;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public class BatchBusiness :BaseBusiness, IBatchBusiness
    {
        private readonly IBatchRepository _batchRepository;
        public BatchBusiness(ILogger<BatchBusiness> logger, IBatchRepository batchRepository) :base(logger) { _batchRepository = batchRepository; }

        public async Task<string> AddBatch(BatchModel batchModel)
        {
            try
            {
                return await _batchRepository.AddBatch(batchModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchBusiness.AddBatch");
                throw;
            }
        }

       

        public async Task<string> DeleteBatch(BatchModel batchModel)
        {
            try
            {
                return await _batchRepository.DeleteBatch(batchModel);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchBusiness.DeleteBatch");
                throw;
            }
        }

        public async Task<BatchModel> GetBatch(BatchSearchModel searchModel)
        {
            try
            {
                return await GetBatch(searchModel);               

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchBusiness.GetBatch");
                throw;
            }
        }

        public async Task<IEnumerable<BatchModel>> SearchBatches(BatchSearchModel searchModel)
        {
            try
            {
                return await _batchRepository.SearchBatches(searchModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchBusiness.SearchBatches");
                throw;
            }
        }

        public async Task<string> UpdateBatch(BatchModel batchModel)
        {
            try
            {
                return await _batchRepository.UpdateBatch(batchModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchBusiness.UpdateBatch");
                throw;
            }
        }
    }
}
