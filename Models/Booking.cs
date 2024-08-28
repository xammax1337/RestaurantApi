namespace RestaurantApi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime TimeBooked { get; set; }
        public int CustomerCount { get; set; }

        public int TableId { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public Table Table { get; set; }
    }
}
