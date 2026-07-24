namespace DataManagement.Domain
{
    public class AddObjectOfSaleInPurchaseInvoice
    {
        public string DocumentId { get; set; }
        public string ContractId { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
        public string Warehouse { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
