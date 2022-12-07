using RecoveryAppLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IManagerData
    {
        Task<int> CreateManager(ManagerModel manager);
        Task<List<ManagerModel>> GetManagerAll();
        Task<ManagerModel> GetManagerById(int managerId);
        Task<int> ManagerDeactivate(int managerId);
        Task<int> ManagerReactivate(int managerId);
        Task<int> UpdateManager(int managerId, string firstName, string lastName, string email, string phone);
    }
}