using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class ScreeningRoom
    {
        public ScreeningRoom()
        {
        }
        public int ScreeningRoomId { get; set; }
        public int Capacity { get; set; }
        public int CinemaId { get; set; }
        [Required] public Cinema Cinema { get; set; }
    }
}
