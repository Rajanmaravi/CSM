using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class AspectDaoModel
    {
        public int id { get; set; }
        public string AspectCode { get; set; }
        public string AspectName { get; set; }
        public int  Rating {get;set;}
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
