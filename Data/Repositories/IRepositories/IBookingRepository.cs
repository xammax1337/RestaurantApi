using RestaurantApi.Models;

namespace RestaurantApi.Data.Repositories.IRepositories
{
    public interface IBookingRepository
    {
        Task AddBookingAsync (Booking booking);
        Task DeleteBookingAsync(int id);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id); 
        Task<Booking> GetBookingByCustomerAsync(string customerName); 
        Task<Booking> GetBookingByTableAsync(int tableNumber); 
        Task UpdateBookingAsync(int id, Booking updatedBooking);
    }
}
