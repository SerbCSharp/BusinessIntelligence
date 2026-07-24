using DataFromExcel.Domain;

namespace DataFromExcel.Application.Interfaces
{
    public interface ISaveData
    {
        Task ObjectOfSaleInPurchasePaymentAsync(IEnumerable<ObjectOfSaleInPurchasePayment> objectOfSaleInPurchasePayments);
        Task ObjectOfSaleInContractAsync(IEnumerable<ObjectOfSaleInContract> objectOfSaleInContracts);
    }
}
