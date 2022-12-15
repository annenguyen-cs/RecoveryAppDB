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
    public class UAFollowUpData : IUAFollowUpData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public UAFollowUpData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;

        }

        public async Task<UAFollowUpModel> GetUAFollowUpByResultId(int id)
        {
            var followUp = await _dataAccess.LoadData<UAFollowUpModel, dynamic>("sp_UAFollowUpByResultId", new { Id = id }, _connectionString.SqlConnectionName);

            return followUp.FirstOrDefault();
        }

        public async Task<int> CreateUAFollowUp(int uaId, string summary, DateTime followUpDate)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Summary", summary);
            p.Add("FollowUpDate", followUpDate);
            p.Add("UAId", uaId);

            await _dataAccess.SaveData("sp_UAFollowUpInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateUAFollowUp(int uaId, string summary, DateTime followUpDate)
        {
            return _dataAccess.SaveData("sp_UAFollowUpInsert", new { UAId = uaId, Summary = summary, FollowUpDate = followUpDate }, _connectionString.SqlConnectionName);
        }





    }
}
