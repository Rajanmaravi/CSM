using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Csm.JseFeedback.Model.Dao
{
    public class RaFeedbackDaoDetailsModel
    {
        public int FeedbackId { get; set; }
       public string Rating{get;set;}
       public string FeedbackName{get;set;}
       public string EmployeeName{get;set;}
       public string FirstName{get;set;}
       public string MiddleName{get;set;}
       public string LastName{get;set;}
       public string EmployeeCode{get;set;}
       public string RaName{get;set;}
       public string RaCode{get;set;}
    }
}
