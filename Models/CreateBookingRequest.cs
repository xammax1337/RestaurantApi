namespace RestaurantApi.Models
{
    public class CreateBookingRequest
    {
        public int CustomerId { get; set; }
        public DateTime BookingTime { get; set; }
        public int SeatsRequired { get; set; }
    }
}
