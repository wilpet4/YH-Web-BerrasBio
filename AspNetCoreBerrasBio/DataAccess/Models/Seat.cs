using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int ScreeningId { get; set; }
        [Required] public Screening Screening { get; set; }
        public bool IsOccupied { get; set; }
    }
}
