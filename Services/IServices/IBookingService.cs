using RestaurantApi.Models;

namespace RestaurantApi.Services.IServices
{
    public interface IBookingService
    {
        Task CreateBookingAsync(string email, DateTime bookingTime, int seatsRequired);
        Task AddBookingAsync(Booking booking);
        Task DeleteBookingAsync(int id);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> GetBookingByCustomerAsync(string customerName);
        Task<Booking> GetBookingByTableAsync(int tableNumber);
        Task UpdateBookingAsync(int id, Booking updatedBooking);
    }
}
