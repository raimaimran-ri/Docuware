using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Domain.Entities
{
    [Table("user_role")]
    public class UserRoles
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}