using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Domain.Entities
{
    [Table("event")]
    public class Event
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public DateTime created_on { get; set; }
        public int created_by { get; set; }
        public User User { get; set; }
        public ICollection<EventRegistration> EventRegistrations { get; set; }
    }
}