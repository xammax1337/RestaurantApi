namespace RestaurantApi.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int TableNumber {  get; set; }
        public int Seats { get; set; }
        public bool Available { get; set; }

        public Booking Booking { get; set; }
    }
}
