using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class ScreeningRoom
    {
        public ScreeningRoom()
        {
            Seats = new List<Seat>();
        }
        public int ScreeningRoomId { get; set; }
        public int Capacity { get; set; }
        public int CinemaId { get; set; }
        [Required] public Cinema Cinema { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
