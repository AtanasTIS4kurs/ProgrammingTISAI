namespace MovieStoreTISAI.Models.DTO
{
    public class Movie
    {
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public required List<string> Actors { get; set; } 
    }
}
