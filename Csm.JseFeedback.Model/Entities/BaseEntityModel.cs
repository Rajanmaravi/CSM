namespace Csm.JseFeedback.Model
{
    public class BaseEntityModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? LoggedInUser { get; set; }

    }
}
