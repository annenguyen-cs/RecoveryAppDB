using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IUAResultData
    {
        Task<int> CreateUAResult(int tenantId, bool result, DateTime testDate, int id);
        Task<List<UAResultModel>> GetUAResultByDate(DateTime testDate);
        Task<UAResultModel> GetUAResultById(int id);
        Task<UAResultModel> GetUAResultByTenantId(int tenantId);
        Task<int> UpdateUAResult(int tenantId, bool result, DateTime testDate, int id);
    }
}