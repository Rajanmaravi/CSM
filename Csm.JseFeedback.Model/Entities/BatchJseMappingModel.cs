using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class BatchJseMappingModel :BaseEntityModel
    {
        public int BatchId { get; set; }
        public int JseId { get; set; }       
    }
}
