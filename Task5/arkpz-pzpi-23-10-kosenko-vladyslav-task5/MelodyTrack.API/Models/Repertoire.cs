namespace MelodyTrack.API.Models
{
    public class Repertoire
    {
        public int RepertoireID { get; set; }
        public string? Title { get; set; }      
        public string? Composer { get; set; }  
        public string? Status { get; set; }    
        public int StudentID { get; set; }     
    }
}