using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class JseUserRAMapModel: BaseDaoModel
    {
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string RaCode { get; set; }
        [Required]
        public string RaEmail { get; set; }
        [Required]
        public int? BatchId { get; set; }
        public int? TechnologyId { get; set; }
    }
}
