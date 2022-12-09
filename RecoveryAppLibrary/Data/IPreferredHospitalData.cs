using RecoveryAppLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IPreferredHospitalData
    {
        Task<int> CreatePreferredHospital(string hospitalName, string street, string city, string zipCode, string phone, int tenantId);
        Task<List<PreferredHospitalModel>> GetPreferredHospitalByTenantId(int tenantId);
        Task<int> UpdatePreferredHospital(int id, string hospitalName, string street, string city, string zipCode, string phone, int tenantId);
    }
}