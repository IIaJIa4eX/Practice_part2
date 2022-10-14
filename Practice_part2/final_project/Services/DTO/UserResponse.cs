namespace final_project.Services.DTO
{
    //For_Review

    public class UserResponse
    {
        public string Message { get; set; }
        public int ResponseCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int Id { get; set; } = 0;
    }
}
