using Dapper;
using RecoveryAppLibrary.Database;
using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public class PaymentHistoryData : IPaymentHistoryData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public PaymentHistoryData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<PaymentHistoryModel>> GetPaymentHistoryAll()
        {
            return _dataAccess.LoadData<PaymentHistoryModel, dynamic>("sp_PaymentHistoryAll", new { }, _connectionString.SqlConnectionName);
        }

        public async Task<PaymentHistoryModel> GetPaymentHistoryById(int id)
        {
            var pHistory = await _dataAccess.LoadData<PaymentHistoryModel, dynamic>("sp_PaymentHistoryById", new { Id = id }, _connectionString.SqlConnectionName);

            return pHistory.FirstOrDefault();
        }

        public async Task<PaymentHistoryModel> GetPaymentHistoryByTenantId(int tenantId)
        {
            var tenantPaymentHistory = await _dataAccess.LoadData<PaymentHistoryModel, dynamic>("sp_PaymentHistoryByTenantId", new { TenantId = tenantId }, _connectionString.SqlConnectionName);

            return tenantPaymentHistory.FirstOrDefault();
        }

        public async Task<int> CreatePaymentHistory(decimal amountPaid, DateTime transactionDate, string paymentType, int tenantId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("AmountPaid", amountPaid);
            p.Add("TransactionDate", transactionDate);
            p.Add("PaymentType", paymentType);
            p.Add("TenantId", tenantId);

            await _dataAccess.SaveData("sp_PaymentHistoryInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");

        }

        public Task<int> UpdatePaymentHistory(int id, decimal amountPaid, DateTime transactionDate, string paymentType, int tenantId)
        {
            return _dataAccess.SaveData("sp_PaymentHistoryUpdate",
                new
                {
                    Id = id,
                    AmountPaid = amountPaid,
                    TransactionDate = transactionDate,
                    PaymentType = paymentType,
                    TenantId = tenantId
                },
                _connectionString.SqlConnectionName);
        }
    }
}
