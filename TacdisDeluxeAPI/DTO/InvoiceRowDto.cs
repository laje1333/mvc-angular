namespace TacdisDeluxeAPI.DTO
{
    public class InvoiceRowDto
    {
        public int? Id { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public double? UnitCost { get; set; }
        public int? Quantity { get; set; }
        public double? Vat { get; set; }
        public double? InvoiceRowAmount { get; set; }
    }
}