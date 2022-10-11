using SafeProject.Services.Interfaces;

namespace SafeProject.Models
{
    public class CommonCardResponse : IOperationResult
    {
        public int CardId { get; set; }
        public int ErrorCode { get; set; }
        public string? Message { get; set; }
    }
}
