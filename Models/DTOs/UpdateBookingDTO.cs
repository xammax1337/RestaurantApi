namespace RestaurantApi.Models.DTOs
{
    public class UpdateBookingDTO
    {
        public DateTime TimeBooked { get; set; }
        public int CustomerCount { get; set; }
        public int TableId { get; set; }
    }
}
