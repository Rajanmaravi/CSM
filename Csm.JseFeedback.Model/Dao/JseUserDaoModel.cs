using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class JseUserDaoModel:BaseDaoModel
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
        public string PmCode { get; set; }
        [Required]
        public string PmEmail { get; set; }
        public string? Location { get; set; }
        public string? ProjectName { get; set; }
        public int? BatchId { get; set; }
        public int? TechnologyId { get; set; }
    }
}
