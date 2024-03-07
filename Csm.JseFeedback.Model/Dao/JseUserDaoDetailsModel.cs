using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class JseUserDaoDetailsModel
    {
       public int Id { get; set; }
       public string EmployeeCode { get; set; }
       public string FirstName { get; set; }
       public string MiddleName { get; set; }
       public string LastName { get; set; }
       public string? empFullName { get; set; }
       public string Email { get; set; }
	   public string Mobile { get; set; }
       public string RaCode { get; set; }
       public string RaName { get; set; }
       public string RaPhone { get; set; }
       public string RaEmail { get; set; }
       public string PmCode { get; set; }
       public string PmEmail { get; set; }
       public string Location { get; set; }	
	   public int BatchId { get; set; }
       public string BatchCode { get; set; }
       public string BatchName { get; set; }
       public string Month { get; set; }
       public string Year { get; set; }
       public int TechnologyId { get; set; }
       public string TechnologyCode { get; set; }
       public string TechnologyName { get; set; }
	   public string ProjectName { get; set; }
       public bool IsActive { get; set; }	
	   public bool IsDeleted { get; set; }
       public string CreatedOn { get; set; }
       public string ModifiedOn { get; set; }
       public string CreatedBy { get; set; }
       public string ModifiedBy { get; set; }
    }
}
