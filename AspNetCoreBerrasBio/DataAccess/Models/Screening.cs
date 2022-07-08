using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Screening
    {
        public Screening()
        {
            Seats = new List<Seat>();
            if (IsRecurring == true)
            {
                DateTime = DateTime.Now;
            }
        }
        public int ScreeningId { get; set; }
        public bool IsRecurring { get; set; }
        public int ScreeningRoomId { get; set; }
        [Required] public ScreeningRoom ScreeningRoom { get; set; }
        [Required] public int Capacity { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public int MovieId { get; set; }
        [Required] public Movie Movie { get; set; }
        public DateTime DateTime { get; set; }
        public float Price { get; set; }
        [NotMapped] public string GenresAsString { get // Väldigt "ful" lösning men fungerar bra. Bör annars göras i front-end 
            {                                          // men lyckades inte på det sätt jag hade tänkt mig.
                string result = string.Empty;
                foreach (Genre genre in Movie.Genres)
                {
                    result += $"{genre.GenreName} ";
                }
                return result;
            } 
        }
        [NotMapped] public int AvailableSeats
        {
            get
            {
                int result = 0;
                foreach (Seat seat in Seats)
                {
                    if (seat.IsOccupied == false)
                    {
                        result++;
                    }
                }
                return result;
            }
        }
    }
}
