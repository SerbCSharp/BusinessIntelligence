using System.ComponentModel.DataAnnotations;

namespace DataFromExcel.Domain
{
    public class ObjectOfSaleInSalesPayment
    {
        [Key]
        public string DocumentId { get; set; }
        public string ContractId { get; set; }
        public string Property { get; set; }
    }
}
