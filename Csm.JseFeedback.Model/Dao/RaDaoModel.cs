using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Csm.JseFeedback.Model.Dao
{
    public class RaDaoModel
    {
       public int Id { get; set; }
       public string RaCode { get; set; }
       public string RaName { get; set; }
       public string RaEmail { get; set; }
       public string RaPhone { get; set; }
       public bool Status { get; set; }
       public bool IsActive { get; set; }
       public bool IsDelete { get; set; }
       public DateTime CreatedOn { get; set; }
       public DateTime ModifiedOn { get; set; }
       public string CreatedBy { get; set; }
       public string ModifiedBy { get; set; }
    }
}
