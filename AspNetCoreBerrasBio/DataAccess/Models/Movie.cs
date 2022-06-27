using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Movie
    {
        public Movie()
        {
            Genres = new List<Genre>();
        }
        public int MovieId { get; set; }
        [Required, MaxLength(70)] public string Name { get; set; }
        public string Description { get; set; }
        public int Runtime { get; set; }
        public int AgeRestriction { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public int DirectorId { get; set; }
        [Required] public Director Director { get; set; }
    }
}
