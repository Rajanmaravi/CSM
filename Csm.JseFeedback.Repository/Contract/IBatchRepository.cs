using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public interface IBatchRepository
    {
        Task<IEnumerable<BatchModel>> SearchBatches(BatchSearchModel batchSearch);
        Task<BatchModel> GetBatch(BatchSearchModel batchSearch);
        Task<string> AddBatch(BatchDaoModel batchModel);
        Task<string> UpdateBatch(BatchDaoModel batchModel);
        Task<string> DeleteBatch(BatchDaoModel batchModel);
        Task<List<BatchDetailsDaoModel>> GetBatchList();
        Task<List<RaDaoModel>> GetRa();
    }
}
