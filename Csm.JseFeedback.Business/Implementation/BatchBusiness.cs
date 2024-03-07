using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
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
        public BatchBusiness(ILogger<BatchBusiness> logger, IBatchRepository batchRepository) :base(logger)
        { 
            _batchRepository = batchRepository??throw new ArgumentNullException(nameof(batchRepository)); 
        }

        public async Task<string> AddBatch(BatchDaoModel batchModel)
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

       

        public async Task<string> DeleteBatch(BatchDaoModel batchModel)
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

        public async Task<string> UpdateBatch(BatchDaoModel batchModel)
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

        public async Task<List<BatchDetailsDaoModel>> GetBatchList()
        {
            try
            {
                return await _batchRepository.GetBatchList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchBusiness.GetBatchList");
                throw;
            }
        }

        public async Task<List<RaDaoModel>> GetRa()
        {
            try
            {
                return await _batchRepository.GetRa();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchBusiness.GetRa");
                throw;
            }
        }
    }
}
