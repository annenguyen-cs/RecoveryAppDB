using RecoveryAppLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface ITenantData
    {
        Task<int> CreateTenant(TenantModel tenant);
        Task<List<TenantModel>> GetTenantAll();
        Task<List<TenantModel>> GetTenantAllByOrg(int orgId);
        Task<TenantModel> GetTenantById(int tenantId);
        Task<List<TenantModel>> GetTenantByManager(int managerId);
        Task<int> TenantDeactivate(int tenantId);
        Task<int> TenantReactivate(int tenantId);
        Task<int> UpdateTenant(int tenantId, string firstName, string lastName, string email, string phone, int managerId);
    }
}