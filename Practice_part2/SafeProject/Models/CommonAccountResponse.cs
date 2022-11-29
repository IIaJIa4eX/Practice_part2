using SafeProject.Services.Interfaces;

namespace SafeProject.Models
{
    //for_review
    public class CommonAccountResponse : IOperationResult
    {
        public int AccountId { get; set; }
        public int ErrorCode { get; set; }
        public string? Message { get; set; }
    }
}
