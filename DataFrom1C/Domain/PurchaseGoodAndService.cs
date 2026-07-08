using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class PurchaseGoodAndService
    {
        [Key]
        public Guid RowId { get; set; }
        public string DocumentId { get; set; }
        public string NomenclatureId { get; set; }
        public string UnitsOfMeasurementId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}
