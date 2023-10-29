using Csm.JseFeedback.Model.Search;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Model.Validator
{
    public interface IFeedbackValidationService
    {
        ValidationResult ValidateDao(FeedbackDaoModel feedbackDaoModel);
        ValidationResult ValidateSearch(FeedbackSearchModel feedbackSearch);
    }
    public class FeedbackValidationService : IFeedbackValidationService
    {
        private readonly FeedbackSearchValidator _searchValidator;
        private readonly FeedbackDaoValidator _daoValidator;
        public FeedbackValidationService(FeedbackSearchValidator searchValidator,FeedbackDaoValidator daoValidator)
        {
            _searchValidator = searchValidator ?? throw new ArgumentNullException(nameof(searchValidator));
            _daoValidator = daoValidator ?? throw new ArgumentNullException(nameof(daoValidator));
        }
        public ValidationResult ValidateDao(FeedbackDaoModel feedbackDaoModel)
        {
            return _daoValidator.Validate(feedbackDaoModel);
        }

        public ValidationResult ValidateSearch(FeedbackSearchModel feedbackSearch)
        {
            return _searchValidator.Validate(feedbackSearch);
        }
    }
}
