using DataAccess.Models;

namespace BerrasBio.Models
{
    public class ScreeningModel
    {
        public int ScreeningId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public int Runtime { get; set; }
        public int AgeRestriction { get; set; }
        public string Genres { get; set; }
        public string DirectorName { get; set; }
    }
}
