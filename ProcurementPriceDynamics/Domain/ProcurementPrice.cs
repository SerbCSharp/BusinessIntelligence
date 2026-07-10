namespace ProcurementPriceDynamics.Domain
{
    public class ProcurementPrice
    {
        //public DateTime Date { get; set; }
        //public decimal DocumentAmount { get; set; }
        //public string Contractor { get; set; }
        //public string ProductAndService { get; set; }
        //public decimal Quantity { get; set; }
        //public string Unit { get; set; }
        //public decimal Price { get; set; }
        //public decimal Amount { get; set; }
        //public string Warehouse { get; set; }
        public string DocumentId { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public string ContractId { get; set; }
        public string PaymentPurpose { get; set; }
        public string Name { get; set; }
    }
}
