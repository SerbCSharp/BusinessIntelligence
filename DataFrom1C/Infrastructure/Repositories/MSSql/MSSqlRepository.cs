using DataFrom1C.Application.Interfaces;
using DataFrom1C.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFrom1C.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(DataContext dataContext) : ISaveData
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task PurchasePaymentAsync(IEnumerable<PurchasePayment> purchasePayments)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE PurchasePayments");
            await _dataContext.PurchasePayments.AddRangeAsync(purchasePayments);
            await _dataContext.SaveChangesAsync();
        }

        public async Task PurchaseInvoiceAsync(IEnumerable<PurchaseInvoice> purchaseInvoices)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE PurchaseInvoices");
            await _dataContext.PurchaseInvoices.AddRangeAsync(purchaseInvoices);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SalesInvoiceAsync(IEnumerable<SalesInvoice> salesInvoices)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE SalesInvoices");
            await _dataContext.SalesInvoices.AddRangeAsync(salesInvoices);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SalesPaymentAsync(IEnumerable<SalesPayment> salesPayments)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE SalesPayments");
            await _dataContext.SalesPayments.AddRangeAsync(salesPayments);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ContractAsync(IEnumerable<Contract> contract)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Contracts");
            await _dataContext.Contracts.AddRangeAsync(contract);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ContractorAsync(IEnumerable<Contractor> contractor)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Contractors");
            await _dataContext.Contractors.AddRangeAsync(contractor);
            await _dataContext.SaveChangesAsync();
        }

        public async Task PurchaseGoodAndServiceAsync(IEnumerable<PurchaseGoodAndService> purchaseGoodAndService)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE PurchaseGoodsAndServices");
            await _dataContext.PurchaseGoodsAndServices.AddRangeAsync(purchaseGoodAndService);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SalesGoodAndServiceAsync(IEnumerable<SalesGoodAndService> salesGoodAndService)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE SalesGoodsAndServices");
            await _dataContext.SalesGoodsAndServices.AddRangeAsync(salesGoodAndService);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UnitAsync(IEnumerable<Unit> units)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Units");
            await _dataContext.Units.AddRangeAsync(units);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ProductAndServiceAsync(IEnumerable<ProductAndService> productsAndServices)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE ProductsAndServices");
            await _dataContext.ProductsAndServices.AddRangeAsync(productsAndServices);
            await _dataContext.SaveChangesAsync();
        }

        public async Task WarehouseAsync(IEnumerable<Warehouse> warehouses)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Warehouses");
            await _dataContext.Warehouses.AddRangeAsync(warehouses);
            await _dataContext.SaveChangesAsync();
        }
    }
}
