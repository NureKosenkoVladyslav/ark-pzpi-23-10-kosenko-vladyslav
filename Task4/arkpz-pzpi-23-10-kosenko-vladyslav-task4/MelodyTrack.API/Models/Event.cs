using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MelodyTrack.API.Models
{
    [Table("Events")]
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public string? Title { get; set; }
        public DateTime EventDate { get; set; }
        public string? EventType { get; set; }
    }
}