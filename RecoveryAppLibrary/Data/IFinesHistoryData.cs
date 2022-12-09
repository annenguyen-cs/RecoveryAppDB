using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IFinesHistoryData
    {
        Task<int> CreateFinesHistory(int tenantId, bool fromBalance, decimal amount, DateTime transactionDate);
        Task<int> FineHistoryUpdate(int id, int tenantId, bool fromBalance, decimal amount, DateTime transactionDate);
        Task<List<FinesHistoryModel>> GetFinesHistoryAll();
        Task<FinesHistoryModel> GetFinesHistoryById(int id);
        Task<FinesHistoryModel> GetFinesHistoryByTenantId(int tenantId);
    }
}