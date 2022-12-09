using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IPaymentHistoryData
    {
        Task<int> CreatePaymentHistory(decimal amountPaid, DateTime transactionDate, string paymentType, int tenantId);
        Task<List<PaymentHistoryModel>> GetPaymentHistoryAll();
        Task<PaymentHistoryModel> GetPaymentHistoryById(int id);
        Task<PaymentHistoryModel> GetPaymentHistoryByTenantId(int tenantId);
        Task<int> UpdatePaymentHistory(int id, decimal amountPaid, DateTime transactionDate, string paymentType, int tenantId);
    }
}