using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class JseRAMapDaoDetailsModel
    {
       public int Id { get; set; }
       public string EmployeeCode { get; set; }
       public string FirstName { get; set; }
       public string MiddleName { get; set; }
       public string LastName { get; set; }
       public string Email { get; set; }
       public string Mobile { get; set; }
       public string RaCode { get; set; }
       public string RaEmail { get; set; }
       public int BatchId { get; set; }
       public int TechnologyId { get; set; }
       public bool IsActive { get; set; }
       public bool IsDeleted { get; set; }
	   public DateTime CreatedOn { get;set; }
       public string CreatedBy { get; set; }
       public DateTime ModifiedOn { get; set; }
       public string ModifiedBy { get; set; }
       public string RaName { get; set; }
       public string BatchName { get; set; }
       public string TechnologyName { get; set; }
       public string BatchCode { get; set; }
       public string TechnologyCode { get; set; }
    }
}
