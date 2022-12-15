using Dapper;
using RecoveryAppLibrary.Database;
using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public class IncidentReportData : IIncidentReportData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public IncidentReportData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<IncidentReportModel>> GetIncidentReportAll()
        {
            return _dataAccess.LoadData<IncidentReportModel, dynamic>("sp_IncidentReportAll", new { }, _connectionString.SqlConnectionName);
        }

        public Task<List<IncidentReportModel>> GetIncidentReportByTenantId(int tenantId)
        {
            return _dataAccess.LoadData<IncidentReportModel, dynamic>("sp_IncidentReportAll", new { TenantId = tenantId }, _connectionString.SqlConnectionName);
        }

        public async Task<int> CreateIncidentReport(int tenantId, string summary, DateTime incidentDate)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("TenantId", tenantId);
            p.Add("Summary", summary);
            p.Add("IncidentDate", incidentDate);

            await _dataAccess.SaveData("sp_IncidentReportInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");

        }

        public Task<int> UpdateIncidentReport(int tenantId, string summary, DateTime incidentDate)
        {

            return _dataAccess.SaveData("sp_IncidentReportInsert", new { TenantId = tenantId, Summary = summary, IncidentDate = incidentDate }, _connectionString.SqlConnectionName);

        }


    }
}
