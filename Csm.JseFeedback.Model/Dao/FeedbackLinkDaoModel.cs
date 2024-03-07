using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Dao
{
    public class FeedbackLinkDaoModel 
    {
        [Required]
        public string  EmployeeCode{get;set;}
        [Required]
        public string  FirstName{get;set;}
        public string  MiddleName{get;set;}
        [Required]
        public string  LastName{get;set;}
        [Required]
        public string  Email{get;set;}
        public string  Mobile{get;set;}
        [Required]
        public string  RaCode{get;set;}
        [Required]
        public string  RaEmail{get;set;}
        [Required]
        public string  PmCode{get;set;}
        [Required]
        public string  ProjectName{get;set;}
        [Required]
        public string  BatchCode{get;set;}
        [Required]
        public string BatchName{get;set;}
        [Required]
        public string TechnologyName{get;set;}
        [Required]
        public string TechnologyCode{get;set;}
        public string? LoggedInUser { get; set; }
    }
}
