using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Screening
    {
        public int ScreeningId { get; set; }
        public bool IsRecurring { get; set; }
        public int ScreeningRoomId { get; set; }
        [Required] public ScreeningRoom ScreeningRoom { get; set; }
        public int MovieId { get; set; }
        [Required] public Movie Movie { get; set; }
        public float Price { get; set; }
    }
}
