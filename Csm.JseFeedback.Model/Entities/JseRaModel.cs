using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Entities
{
    public class JseRaModel : BaseEntityModel
    {
       [Required]
       public string RaCode { get; set; }
       [Required]
       public string RaName { get; set; }
       [Required]
       public string RaEmail { get; set; }
       [Required]
       public string RaPhone { get; set; }
    }
}
