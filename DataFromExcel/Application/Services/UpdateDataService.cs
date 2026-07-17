using DataFromExcel.Application.Interfaces;

namespace DataFromExcel.Application.Services
{
    public class UpdateDataService(IGetData getData, ISaveData saveData)
    {
        private readonly IGetData _getData = getData;
        private readonly ISaveData _saveData = saveData;

        public async Task ObjectOfSaleInPurchasePaymentAsync()
        {
            var getObjectOfSaleInPurchasePayment = _getData.ObjectOfSaleInPurchasePayment();
            await _saveData.ObjectOfSaleInPurchasePaymentAsync(getObjectOfSaleInPurchasePayment);
        }
    }
}
