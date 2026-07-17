using Dapper;
using DataManagement.Application.Interfaces;
using DataManagement.Domain;
using System.Data;

namespace DataManagement.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(IDbConnection dbConnection) : IGetData
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<IEnumerable<AddObjectOfSaleInPurchasePayment>> AddObjectOfSaleInPurchasePaymentAsync()
        {
            string sql = "SELECT PurchasePayments.DocumentId, PurchasePayments.ContractId, PurchasePayments.Date, PurchasePayments.Amount, PaymentPurpose, CashFlowItems.Name AS CashFlowItem,\r\nProductGroups.Name AS PropertyContract\r\nFROM PurchasePayments\r\nLEFT JOIN CashFlowItems ON PurchasePayments.CashFlowItemId = CashFlowItems.CashFlowItemId\r\nLEFT JOIN Contracts ON PurchasePayments.ContractId = Contracts.ContractId\r\nLEFT JOIN ProductGroups ON Contracts.ProductGroupId = ProductGroups.ProductGroupId\r\nWHERE NOT EXISTS ( SELECT * FROM ObjectOfSaleInPurchasePayments WHERE ObjectOfSaleInPurchasePayments.DocumentId = PurchasePayments.DocumentId)\r\nAND YEAR(PurchasePayments.Date) > 2025\r\nORDER BY PurchasePayments.Date";
            return await _dbConnection.QueryAsync<AddObjectOfSaleInPurchasePayment>(sql);
        }
    }
}

