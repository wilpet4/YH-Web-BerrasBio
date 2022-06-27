using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Cinema
    {
        public Cinema()
        {
            ScreeningRooms = new List<ScreeningRoom>();
            if (String.IsNullOrWhiteSpace(Name))
            {
                Name = "undefined";
            }
        }
        public int CinemaId { get; set; }
        [MaxLength(70)] public string Name { get; set; }
        public ICollection<ScreeningRoom> ScreeningRooms { get; set; }
    }
}
