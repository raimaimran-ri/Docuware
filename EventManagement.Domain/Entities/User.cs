using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Domain.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string phone_number { get; set; }
        public int user_role_id { get; set; }
        public UserRoles User_role { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<EventRegistration> EventRegistrations { get; set; }
    }
}