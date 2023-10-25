using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class BatchSearchModel
    {
        public int? Id { get; set; }
        public string? BatchCode { get; set; }
        public string? Year { get; set; }
        public string? Month { get; set; }
        public string? BatchName { get; set; }
    }
}
