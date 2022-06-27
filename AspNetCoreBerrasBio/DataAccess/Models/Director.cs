using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Director
    {
        public Director()
        {
            DirectedMovies = new List<Movie>();
        }
        public int DirectorId { get; set; }
        [Required, MaxLength(70)] public string Name { get; set; }
        public ICollection<Movie> DirectedMovies { get; set;}
    }
}
