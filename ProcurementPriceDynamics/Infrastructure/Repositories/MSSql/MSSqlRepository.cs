using Dapper;
using ProcurementPriceDynamics.Application.Interfaces;
using ProcurementPriceDynamics.Domain;
using System.Data;

namespace ProcurementPriceDynamics.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(IDbConnection dbConnection) : IGetData
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync()
        {
            string sql = "SELECT DocumentId, Date, Amount, ContractId, PaymentPurpose, CashFlowItems.Name AS CashFlowItem " +
                "FROM PurchasePayments " +
                "LEFT JOIN CashFlowItems ON PurchasePayments.CashFlowItemId = CashFlowItems.CashFlowItemId";
            return await _dbConnection.QueryAsync<ProcurementPrice>(sql);

            //string sql = "SELECT PurchaseInvoices.Date, PurchaseInvoices.Amount AS DocumentAmount, " +
            //    "PurchaseGoodsAndServices.Quantity, Units.Name AS Unit, ProductsAndServices.Name AS ProductAndService, " +
            //    "PurchaseGoodsAndServices.Price, PurchaseGoodsAndServices.Amount," +
            //    "Contractors.Name AS Contractor, Warehouses.Name AS Warehouse " +
            //    "FROM PurchaseInvoices " +
            //    "LEFT JOIN PurchaseGoodsAndServices ON PurchaseInvoices.DocumentId = PurchaseGoodsAndServices.DocumentId " +
            //    "LEFT JOIN Contracts ON PurchaseInvoices.ContractId = Contracts.ContractId " +
            //    "LEFT JOIN Contractors ON Contracts.ContractorId = Contractors.ContractorId " +
            //    "LEFT JOIN Warehouses ON PurchaseInvoices.WarehouseId = Warehouses.WarehouseId " +
            //    "LEFT JOIN Units ON PurchaseGoodsAndServices.UnitId = Units.UnitId " +
            //    "LEFT JOIN ProductsAndServices ON PurchaseGoodsAndServices.ProductAndServiceId = ProductsAndServices.ProductAndServiceId " +
            //    "ORDER BY PurchaseInvoices.Date";
            //return await _dbConnection.QueryAsync<ProcurementPrice>(sql);
        }
    }
}
