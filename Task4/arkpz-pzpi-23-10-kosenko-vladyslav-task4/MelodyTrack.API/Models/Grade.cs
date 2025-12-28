using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MelodyTrack.API.Models
{
    [Table("Grades")]
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }

        public int Value { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }

        
        public int SubjectID { get; set; }
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
    }
}