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
            string sql = "WITH Property AS (SELECT ProductGroups.Name, MoreInformations.ObjectId FROM MoreInformations " +
                            "INNER JOIN ProductGroups ON MoreInformations.ObjectValue = ProductGroups.ProductGroupId " +
                            "WHERE MoreInformations.ValueType LIKE N'%НоменклатурныеГруппы%'), " +
                         "CostItem AS (SELECT CostItems.Name, MoreInformations.ObjectId FROM MoreInformations " +
                            "INNER JOIN CostItems ON MoreInformations.ObjectValue = CostItems.CostItemId " +
                            "WHERE MoreInformations.ValueType LIKE N'%СтатьиЗатрат%') " +
                         "SELECT PurchasePayments.DocumentId, PurchasePayments.ContractId, PurchasePayments.Date, PurchasePayments.Amount, PaymentPurpose, " +
                            "CashFlowItems.Name AS CashFlowItem, Property.Name AS Property, CostItem.Name AS CostItem " +
                         "FROM PurchasePayments " +
                         "LEFT JOIN CashFlowItems ON PurchasePayments.CashFlowItemId = CashFlowItems.CashFlowItemId " +
                         "LEFT JOIN Contracts ON PurchasePayments.ContractId = Contracts.ContractId " +
                         "LEFT JOIN PaymentsDetails ON PurchasePayments.DocumentId = PaymentsDetails.DocumentId " +
                         "LEFT JOIN Property ON PaymentsDetails.InvoiceId = Property.ObjectId " +
                         "LEFT JOIN CostItem ON PaymentsDetails.InvoiceId = CostItem.ObjectId " +
                         "WHERE NOT EXISTS ( SELECT * FROM ObjectOfSaleInPurchasePayments WHERE ObjectOfSaleInPurchasePayments.DocumentId = PurchasePayments.DocumentId) " +
                         "AND YEAR(PurchasePayments.Date) > 2025 " +
                         "ORDER BY PurchasePayments.Date";
            return await _dbConnection.QueryAsync<AddObjectOfSaleInPurchasePayment>(sql);
        }
    }
}

