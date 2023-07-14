namespace POS_Blagajna_Backend.DTOs.ReceiptItemDTOs
{
    public class ReceiptItemDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float DiscountPercentage { get; set; }
        public float DiscountAmmount { get; set; }
        public float TotalPrice { get; set; }
    }
}