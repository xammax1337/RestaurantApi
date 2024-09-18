namespace RestaurantApi.Models
{
    public class CreateBookingRequest
    {
        public string Email { get; set; }
        public DateTime BookingTime { get; set; }
        public int SeatsRequired { get; set; }
    }
}
