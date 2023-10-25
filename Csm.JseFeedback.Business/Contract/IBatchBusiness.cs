using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public interface IBatchBusiness
    {
        Task<IEnumerable<BatchModel>> SearchBatches(BatchSearchModel batchSearch);
        Task<BatchModel> GetBatch(BatchSearchModel batchSearch);
        Task<string> AddBatch(BatchModel batchModel);
        Task<string> UpdateBatch(BatchModel batchModel);
        Task<string> DeleteBatch(BatchModel batchModel);
    }
}
