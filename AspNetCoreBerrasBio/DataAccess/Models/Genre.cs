namespace DataAccess.Models
{
    public class Genre
    {
        public Genre()
        {
            Movies = new List<Movie>();
        }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
