using RestaurantApi.Data.Repositories.IRepositories;
using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;
using RestaurantApi.Services.IServices;

namespace RestaurantApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ITableRepository _tableRepository;
        private readonly ICustomerRepository _customerRepository;
        public BookingService(IBookingRepository bookingRepository, ITableRepository tableRepository, ICustomerRepository customerRepository)
        {
            _bookingRepository = bookingRepository;
            _tableRepository = tableRepository;
            _customerRepository = customerRepository;
        }
        
        public async Task CreateBookingAsync(string email, DateTime bookingTime, int seatsRequired)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(email);

            //Creates a new customer with the email and connects it with the booking.
            if (customer == null)
            {
                customer = new Customer { Email = email, };
                await _customerRepository.AddCustomerAsync(customer);
            }

            var table = await _tableRepository.GetAvailableTableAsync(seatsRequired);
            if (table == null)
            {
                throw new KeyNotFoundException($"No tables with {seatsRequired} seats available found");
            }

            var existingBookings = await _bookingRepository.GetBookingByTableAsync(table.TableId);

            // Check for time conflicts (within 2 hours before or after the new booking time)
            foreach (var existingBooking in existingBookings)
            {
                // Calculate the time difference
                var timeDifference = Math.Abs((existingBooking.TimeBooked - bookingTime).TotalHours);

                // If the difference is less than 2 hours, the table is considered unavailable
                if (timeDifference < 2)
                {
                    throw new InvalidOperationException($"Table is unavailable at the requested time. Existing booking at {existingBooking.TimeBooked}.");
                }
            }

            var booking = new Booking
            {
                TimeBooked = bookingTime,
                CustomerCount = seatsRequired,
                TableId = table.TableId,
                Table = table,
                Customer = customer
            };
            
            await _bookingRepository.AddBookingAsync(booking);

            table.Available = false;
            await _tableRepository.UpdateTableAsync(table);
        }

        public async Task AddBookingAsync(Booking booking)
        {
            await _bookingRepository.AddBookingAsync(booking);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();

            return bookings.Select(b => new BookingDTO
            {
                Id = b.Id,
                TimeBooked = b.TimeBooked,
                CustomerCount = b.CustomerCount,
                TableId = b.TableId,
                Table = b.Table != null ? new TableDTO
                {
                    TableNumber = b.Table.TableNumber,
                    Seats = b.Table.Seats
                } : null,
                CustomerId = b.CustomerId,
                Customer = b.Customer != null ? new CustomerDTO
                {
                    FirstName = b.Customer.FirstName,
                    LastName = b.Customer.LastName,
                    Email = b.Customer.Email,
                    PhoneNumber = b.Customer.PhoneNumber
                } : null
            });;
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _bookingRepository.GetBookingByIdAsync(id);
        }

        public async Task<Booking> GetBookingByCustomerAsync(string customerName)
        {
            return await _bookingRepository.GetBookingByCustomerAsync(customerName);
        }

        public async Task<List<Booking>> GetBookingByTableAsync(int tableId)
        {
            return await _bookingRepository.GetBookingByTableAsync(tableId);
        }

        public async Task UpdateBookingAsync(int id, Booking updatedBooking)
        {
            await _bookingRepository.UpdateBookingAsync(id, updatedBooking);
        }
    }
}
