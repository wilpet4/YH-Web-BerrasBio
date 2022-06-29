using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int ScreeningRoomId { get; set; }
        [Required] public ScreeningRoom ScreeningRoom { get; set; }
        public bool IsOccupied { get; set; }
    }
}
