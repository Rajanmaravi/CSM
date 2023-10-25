using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class TechnologyModel:BaseEntityModel
    {
        [Required]
        public string TechnologyName { get; set; }
          

    }
}
