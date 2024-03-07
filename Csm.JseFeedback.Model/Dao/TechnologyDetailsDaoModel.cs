using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class TechnologyDetailsDaoModel
    {
       public int Id { get; set; }
       public string TechnologyName { get; set; }
       public bool IsActive { get; set; }
       public bool IsDeleted { get; set; }
       public DateTime CreatedOn { get; set; }
       public DateTime ModifiedOn { get; set; }
       public string CreatedBy { get; set; }
       public string ModifiedBy { get; set; }
       public string TechnologyCode { get; set; }
    }
}
