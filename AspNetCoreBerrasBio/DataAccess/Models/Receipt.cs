namespace DataAccess.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; }
        public int SeatNr { get; set; }
    }
}
