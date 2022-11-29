namespace SafeProject.Services.Interfaces
{
    public interface IOperationResult
    {
        public int ErrorCode { get; set; }
        public string? Message { get; set; }
    }
}
