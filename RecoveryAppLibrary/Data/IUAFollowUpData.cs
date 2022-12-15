using RecoveryAppLibrary.Models;
using System;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IUAFollowUpData
    {
        Task<int> CreateUAFollowUp(int uaId, string summary, DateTime followUpDate);
        Task<UAFollowUpModel> GetUAFollowUpByResultId(int id);
        Task<int> UpdateUAFollowUp(int uaId, string summary, DateTime followUpDate);
    }
}