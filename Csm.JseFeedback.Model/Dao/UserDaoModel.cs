using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model

{
    public class UserDaoModel:BaseDaoModel
    {
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiresOn { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public string UserRole { get; set; }
    }
}
