namespace RestaurantApi.Models.DTOs
{
    public class MenuItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
    }
}
