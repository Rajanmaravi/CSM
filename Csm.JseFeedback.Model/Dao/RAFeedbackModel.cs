using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class RAFeedbackModel
    {
        public string EmployeeCode { get; set; }
        public string IsLogger { get; set; }
        public string RaCode { get; set; }
        public Dictionary<int, int> AspectRatings { get; set; }
    }
}
