using Dapper;
using RecoveryAppLibrary.Database;
using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public class IncidentFollowUpData : IIncidentFollowUpData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public IncidentFollowUpData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<IncidentFollowUpModel> GetIncidentFollowUpById(int id)
        {
            var followUp = await _dataAccess.LoadData<IncidentFollowUpModel, dynamic>("sp_IncidentFollowUpById", new { Id = id }, _connectionString.SqlConnectionName);

            return followUp.FirstOrDefault();
        }

        public async Task<IncidentFollowUpModel> GetIncidentFollowUpByReportId(int reportId)
        {
            var followUp = await _dataAccess.LoadData<IncidentFollowUpModel, dynamic>("sp_IncidentFollowUpByReportId", new { Id = reportId }, _connectionString.SqlConnectionName);

            return followUp.FirstOrDefault();
        }
        public async Task<int> CreateIncidentFollowUp(int incidentId, string followUpSummary, DateTime followUpDate)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("IncidentId", incidentId);
            p.Add("FollowUpSummary", followUpSummary);
            p.Add("FollowUpDate", followUpDate);

            await _dataAccess.SaveData("sp_IncidentFollowUpInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateIncidentFollowUp(int incidentId, string followUpSummary, DateTime followUpDate, int id)
        {

            return _dataAccess.SaveData("sp_IncidentFollowUpInsert", new { Id = id, IncidentId = incidentId, FollowUpSummary = followUpSummary, FollowUpDate = followUpDate }, _connectionString.SqlConnectionName);
        }

    }
}
