﻿namespace RestaurantApi.Models.DTOs
{
    public class ViewTableDTO
    {
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public bool Available { get; set; }

        public ICollection<ViewTableBookingDTO> Bookings { get; set; }
    }
}
