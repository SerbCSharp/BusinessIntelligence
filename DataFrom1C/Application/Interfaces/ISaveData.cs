using DataFrom1C.Domain;

namespace DataFrom1C.Application.Interfaces
{
    public interface ISaveData
    {
        Task PurchasePaymentAsync(IEnumerable<PurchasePayment> purchasePayments);
        Task PurchaseInvoiceAsync(IEnumerable<PurchaseInvoice> purchaseInvoices);
        Task SalesInvoiceAsync(IEnumerable<SalesInvoice> salesInvoices);
        Task SalesPaymentAsync(IEnumerable<SalesPayment> salesPayments);
        Task ContractAsync(IEnumerable<Contract> contracts);
        Task ContractorAsync(IEnumerable<Contractor> contractors);
        Task PurchaseGoodAndServiceAsync(IEnumerable<PurchaseGoodAndService> purchaseGoodAndService);
        Task SalesGoodAndServiceAsync(IEnumerable<SalesGoodAndService> salesGoodAndService);
    }
}
