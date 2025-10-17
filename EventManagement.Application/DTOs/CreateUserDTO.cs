namespace EventManagement.Application.DTOs
{
    public class CreateUserDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int UserRoleId { get; set; }
    }
}