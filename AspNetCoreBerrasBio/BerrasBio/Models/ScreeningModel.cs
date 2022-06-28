using DataAccess.Models;

namespace BerrasBio.Models
{
    public class ScreeningModel
    {
        public ScreeningModel()
        {
            Genres = new List<Genre>();
        }
        public int ScreeningId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public int Runtime { get; set; }
        public int AgeRestriction { get; set; }
        public List<Genre> Genres { get; set; }
        public string DirectorName { get; set; }
    }
}
