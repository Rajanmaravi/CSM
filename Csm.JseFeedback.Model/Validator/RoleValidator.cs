using Csm.JseFeedback.Model.Search;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class RoleDaoValidator:AbstractValidator<RoleDaoModel>
    {
        public RoleDaoValidator()
        {
            RuleFor(p => p.RoleCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(1, 100).WithMessage("{PropertyName} should not be empty and should not exceed 100 characters!");

            RuleFor(p => p.Description)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} should be not empty.")
               .Length(1, 50).WithMessage("{PropertyName} should not be empty and should not exceed 50 characters!");

            RuleFor(p => p.LoggedInUser)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(1, 50).WithMessage("{PropertyName} should not be empty and should not exceed 100 characters!");

            RuleFor(p => p.IsActive)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty().WithMessage("{PropertyName} should be not empty.");
              
        }
    }

}
