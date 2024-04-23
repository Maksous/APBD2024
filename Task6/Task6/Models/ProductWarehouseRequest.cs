namespace Task6.Models
{
    public class ProductWarehouseRequest
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
