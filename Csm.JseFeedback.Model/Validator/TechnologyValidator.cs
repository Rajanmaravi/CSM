using Csm.JseFeedback.Model.Search;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class TechnologyDaoValidator:AbstractValidator<TechnologyDaoModel>
    {
        public TechnologyDaoValidator()
        {
            RuleFor(p => p.TechnologyCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(1, 100).WithMessage("{PropertyName} should not be empty and should not exceed 100 characters!");

            RuleFor(p => p.TechnologyName)
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
    public class TechnologySearchValidator : AbstractValidator<TechnologySearchModel>
    {
        public TechnologySearchValidator()
        {
            RuleFor(p => p.TechnologyCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Length(0, 100).WithMessage("{PropertyName} should not exceed 100 characters!");

            RuleFor(p => p.TechnologyName)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .Length(0, 50).WithMessage("{PropertyName} should not exceed 50 characters!");

          

        }
    }

}
