namespace DataManagement.Domain
{
    public class AddObjectOfSaleInPurchasePayment
    {
        public string DocumentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ContractId { get; set; }
        public string PaymentPurpose { get; set; }
        public string CashFlowItem { get; set; }
    }
}
