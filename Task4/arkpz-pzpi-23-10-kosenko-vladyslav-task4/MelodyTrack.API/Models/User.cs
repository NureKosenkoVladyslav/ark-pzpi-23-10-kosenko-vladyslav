using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MelodyTrack.API.Models
{
    [Table("Users")] 
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public int RoleID { get; set; }
    }
}