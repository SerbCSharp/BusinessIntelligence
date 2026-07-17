using DataFromExcel.Application.Interfaces;
using DataFromExcel.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFromExcel.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(ObjectOfSaleContext dataContext) : ISaveData
    {
        private readonly ObjectOfSaleContext _dataContext = dataContext;

        public async Task ObjectOfSaleInPurchasePaymentAsync(IEnumerable<ObjectOfSaleInPurchasePayment> objectOfSaleInPurchasePayments)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE ObjectOfSaleInPurchasePayments");
            await _dataContext.ObjectOfSaleInPurchasePayments.AddRangeAsync(objectOfSaleInPurchasePayments);
            await _dataContext.SaveChangesAsync();
        }
    }
}
