using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class UserModel:BaseEntityModel
    {
            [Required]
            public string EmployeeCode { get; set; }
        [Required]
        public string FirstName    { get; set; }
        [Required]
        public string LastName     { get; set; }
           public string? MiddleName { get; set; }

    }
}
