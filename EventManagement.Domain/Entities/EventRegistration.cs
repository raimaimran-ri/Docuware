using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Domain.Entities
{
    [Table("event_registration")]
    public class EventRegistration
    {
        [Key]
        public int id { get; set; }
        public int event_id { get; set; }
        public Event Event { get; set; }
        public string? name { get; set; }
        public string? phone_number { get; set; }
        public string? email_address { get; set; }
        public int? user_id { get; set; }
        public User? User { get; set; }
    }
}