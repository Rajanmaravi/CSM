using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model
{
    public class BatchDaoValidator:AbstractValidator<BatchDaoModel>
    {
        public BatchDaoValidator()
        {
            RuleFor(p => p.BatchCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(1, 100).WithMessage("{PropertyName} should not be empty and should not exceed 100 characters!");

            RuleFor(p => p.BatchName)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("{PropertyName} should be not empty.")
               .Length(1, 50).WithMessage("{PropertyName} should not be empty and should not exceed 50 characters!");

            RuleFor(p => p.Year)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty().WithMessage("{PropertyName} should be not empty.")
              .Custom((x, context) =>
              {
                  if ((!(int.TryParse(x, out int value)) || value < 0 || value>DateTime.Now.Year))
                  {
                      context.AddFailure($"{x} is not a valid year.");
                  }
                  
              })
              .Length(1, 10).WithMessage("{PropertyName} should not be empty and should not exceed 10 characters!");
            RuleFor(p => p.Month)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty().WithMessage("{PropertyName} should be not empty.")
             .Custom((x, context) =>
             {
                 if ((!(int.TryParse(x, out int value)) || value < 0 || value > 12))
                 {
                     context.AddFailure($"{x} is not a valid month");
                 }

             });
        }
    }

    public class BatchSearchValidator : AbstractValidator<BatchSearchModel>
    {
        public BatchSearchValidator()
        {
            RuleFor(p => p.BatchCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Length(1, 100).WithMessage("{PropertyName} should not be empty and should not exceed 100 characters!");

            RuleFor(p => p.BatchName)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .Length(1, 50).WithMessage("{PropertyName} should not be empty and should not exceed 50 characters!");

            RuleFor(p => p.Year)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .Custom((x, context) =>
              {
                  if ((!(int.TryParse(x, out int value)) || value < 0 || value > DateTime.Now.Year))
                  {
                      context.AddFailure($"{x} is not a valid year.");
                  }

              })
              .Length(1, 10).WithMessage("{PropertyName} should not be empty and should not exceed 10 characters!");
            RuleFor(p => p.Month)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .Custom((x, context) =>
             {
                 if ((!(int.TryParse(x, out int value)) || value < 0 || value > 12))
                 {
                     context.AddFailure($"{x} is not a valid month");
                 }

             });
        }
    }

}
