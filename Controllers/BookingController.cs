﻿using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models;
using RestaurantApi.Services;
using RestaurantApi.Services.IServices;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [Route("CreateBooking")]
        [HttpPost]
        public async Task<ActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            try
            {
                await _bookingService.CreateBookingAsync(request.CustomerId, request.BookingTime, request.SeatsRequired);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteBooking")]
        [HttpPost]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return Ok();
        }

        [Route("GetAllBookings")]
        [HttpGet]
        public async Task<ActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [Route("GetBookingById")]
        [HttpGet]
        public async Task<ActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            return Ok(booking);
        }

        [Route("GetBookingByCustomer")]
        [HttpGet]
        public async Task<ActionResult> GetBookingByCustomer(string name)
        {
            var booking = await _bookingService.GetBookingByCustomerAsync(name);
            return Ok(booking);
        }

        [Route("GetBookingByTable")]
        [HttpGet]
        public async Task<ActionResult> GetBookingByTable(int tableNumber)
        {
            var booking = await _bookingService.GetBookingByTableAsync(tableNumber);
            return Ok(booking);
        }
    }
}
