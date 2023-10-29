using System.ComponentModel.DataAnnotations;

namespace Csm.JseFeedback.Model
{
    public class BaseEntityModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedOn { get; set; }

        public string? ModifiedOn { get; set; }

    }
}
