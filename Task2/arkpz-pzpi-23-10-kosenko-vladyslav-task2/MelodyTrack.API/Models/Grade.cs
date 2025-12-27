namespace MelodyTrack.API.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public int Value { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; } 
        public int StudentID { get; set; } 
    }
}