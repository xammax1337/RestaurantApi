using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Services.IServices
{
    public interface IBookingService
    {
        Task CreateBookingAsync(string email, DateTime bookingTime, int seatsRequired);
        Task AddBookingAsync(Booking booking);
        Task DeleteBookingAsync(int id);
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> GetBookingByCustomerAsync(string customerName);
        Task<List<Booking>> GetBookingByTableAsync(int tableId);
        Task UpdateBookingAsync(int id, Booking updatedBooking);
    }
}
