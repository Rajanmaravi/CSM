using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class FeedbackModel : BaseEntityModel
    {
        [Required]
        public string FeedbackName
        {
            get; set;
        }
    }
}

