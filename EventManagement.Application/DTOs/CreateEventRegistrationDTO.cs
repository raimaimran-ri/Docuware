namespace EventManagement.Application.DTOs
{
    public class CreateEventRegistrationDTO
    {
        public int CreatorUserId { get; set; }
        public int EventId { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhoneNumber { get; set; }
    }
}