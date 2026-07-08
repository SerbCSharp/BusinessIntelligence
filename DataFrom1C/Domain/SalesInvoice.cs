using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class SalesInvoice
    {
        [Key]
        public string DocumentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ContractId { get; set; }
        public string WarehouseId { get; set; }
    }
}
