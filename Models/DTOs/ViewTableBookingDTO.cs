namespace RestaurantApi.Models.DTOs
{
    public class ViewTableBookingDTO
    {
        public int Id { get; set; }
        public DateTime TimeBooked { get; set; }
        public int CustomerCount { get; set; }
    }
}
