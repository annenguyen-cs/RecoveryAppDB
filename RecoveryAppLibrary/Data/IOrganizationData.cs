using RecoveryAppLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IOrganizationData
    {
        Task<int> CreateOrganization(OrganizationModel organization);
        Task<List<OrganizationModel>> GetOrganizationAll();
        Task<OrganizationModel> GetOrganizationById(int Id);
        Task<int> OrganizationDeactivate(int organizationId);
        Task<int> OrganizationReactivate(int organizationId);
        Task<int> UpdateOrganizationTitle(int organizationId, string name);
    }
}