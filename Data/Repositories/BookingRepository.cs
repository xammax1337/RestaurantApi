﻿using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data.Repositories.IRepositories;
using RestaurantApi.Models;
using RestaurantApi.Models.DTOs;

namespace RestaurantApi.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly RestaurantContext _context;
        public BookingRepository(RestaurantContext context)
        {
            _context = context;
        }
        public async Task AddBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            var bookingList = await _context.Bookings
                .Include(b => b.Table)
                .Include(b => b.Customer)
                .ToListAsync();
                
            return bookingList;
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            return booking;
        }

        public async Task<Booking> GetBookingByCustomerAsync(string customerName)
        {
            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(b => b.Customer.LastName == customerName);

            return booking;
        }

        public async Task<List<Booking>> GetBookingByTableAsync(int tableId)
        {
            var booking = await _context.Bookings
                .Where(b => b.TableId == tableId)
                .ToListAsync();

            return booking;
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}
