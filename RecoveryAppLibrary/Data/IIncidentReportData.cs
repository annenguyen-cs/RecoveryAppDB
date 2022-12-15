using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IIncidentReportData
    {
        Task<int> CreateIncidentReport(int tenantId, string summary, DateTime incidentDate);
        Task<List<IncidentReportModel>> GetIncidentReportAll();
        Task<List<IncidentReportModel>> GetIncidentReportByTenantId(int tenantId);
        Task<int> UpdateIncidentReport(int tenantId, string summary, DateTime incidentDate);
    }
}