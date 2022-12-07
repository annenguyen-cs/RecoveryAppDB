using RecoveryAppLibrary.Models;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IEmergencyContactData
    {
        Task<int> CreateEmergencyContact(int tenantId, string firstName, string lastName, string relationship, string phone, string email);
        Task<EmergencyContactModel> GetEmergencyContactByTenantId(int tenantId);
        Task<int> UpdateEmergencyContact(int id, int tenantId, string firstName, string lastName, string relationship, string phone, string email);
    }
}