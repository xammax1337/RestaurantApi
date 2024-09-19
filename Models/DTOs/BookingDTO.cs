namespace RestaurantApi.Models.DTOs
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public DateTime TimeBooked { get; set; }
        public int CustomerCount { get; set; }

        public int TableId { get; set; }
        public TableDTO Table { get; set; }

        public int CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
