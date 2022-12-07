using RecoveryAppLibrary.Models;
using System;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface ITenantDetailsData
    {
        Task<int> CreateTenantDetail(int tenantId, bool depositPaid, DateTime intakeDate, bool rentalStatus, decimal rentAmount, decimal finesBalance);
        Task<TenantDetailsModel> GetTenantDetailByTenantId(int tenantId);
        Task<int> UpdateTenantDetail(int tenantId, bool depositPaid, DateTime intakeDate, bool rentalStatus, decimal rentAmount, decimal finesBalance);
    }
}