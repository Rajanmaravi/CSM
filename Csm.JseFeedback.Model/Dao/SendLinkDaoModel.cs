using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class SendLinkDaoModel
    {
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string RaCode { get; set; }
        public string RaEmail { get; set; }
        public string PmCode { get; set; }
        public string ProjectName { get; set; }
        public string BatchCode { get; set; }
        public string BatchName { get; set; }
        public string TechnologyName { get; set; }
        public string TechnologyCode { get; set; }
        public string LoggedInUser { get; set; }
    }
}
