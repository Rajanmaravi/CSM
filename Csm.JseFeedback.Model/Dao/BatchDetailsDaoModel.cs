using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class BatchDetailsDaoModel
    {
       public int Id { get; set; }
       public string BatchCode { get; set; }
       public string BatchName { get; set; }
       public string Year { get; set; }
       public string Month { get; set; }
       public bool? IsActive { get; set; }
       public bool? IsDeleted { get; set; }
       public DateTime CreatedOn { get; set; }
       public DateTime ModifiedOn { get; set; }
       public string CreatedBy { get; set; }
       public string ModifiedBy { get; set; }
    }
}
