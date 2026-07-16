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
            string sql = "SELECT DocumentId, Date, Amount, ContractId, PaymentPurpose, CashFlowItems.Name AS CashFlowItem " +
                "FROM PurchasePayments " +
                "LEFT JOIN CashFlowItems ON PurchasePayments.CashFlowItemId = CashFlowItems.CashFlowItemId";
            return await _dbConnection.QueryAsync<AddObjectOfSaleInPurchasePayment>(sql);
        }
    }
}
