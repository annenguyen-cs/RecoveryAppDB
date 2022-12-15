using RecoveryAppLibrary.Models;
using System;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IIncidentFollowUpData
    {
        Task<int> CreateIncidentFollowUp(int incidentId, string followUpSummary, DateTime followUpDate);
        Task<IncidentFollowUpModel> GetIncidentFollowUpById(int id);
        Task<IncidentFollowUpModel> GetIncidentFollowUpByReportId(int reportId);
        Task<int> UpdateIncidentFollowUp(int incidentId, string followUpSummary, DateTime followUpDate, int id);
    }
}