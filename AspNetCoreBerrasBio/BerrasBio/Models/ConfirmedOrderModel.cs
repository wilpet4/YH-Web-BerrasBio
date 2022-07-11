using DataAccess;
using DataAccess.Models;

namespace BerrasBio.Models
{
    public class ConfirmedOrderModel
    {
        public int ScreeningId { get; set; }
        public int TicketAmount { get; set; }
        public Screening Screening { get 
            {
                var query = (from s in DbSingleton.Instance.Screenings
                            where s.ScreeningId == ScreeningId
                            select s).First();
                return query;
            } 
        }
    }
}
