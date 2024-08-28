namespace RestaurantApi.Models.DTOs
{
    public class TableDTO
    {
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public bool Available { get; set; }
    }
}
