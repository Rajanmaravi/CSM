using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class FeedbackByRaCodeDaoModel
    {
       public string ProjectName { get; set; }
       public string Mobile { get; set; }
       public string FirstName { get; set; }
       public string MiddleName { get; set; }
       public string LastName { get; set; }
       public string EmployeeCode { get; set; }
	   public string RaCode { get; set; }
	   public string RaName { get; set; }
       public string TotalRating { get; set; }
    }
}
