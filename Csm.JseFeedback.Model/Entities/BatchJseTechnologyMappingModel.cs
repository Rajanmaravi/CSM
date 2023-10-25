using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class BatchJseTechnologyMappingModel:BaseEntityModel
    {
        public int BatchJseId { get; set; }
        public int BatchId { get; set; }
        public int JseId { get; set; }
        public int TechnologyId { get; set; }
    }
}
