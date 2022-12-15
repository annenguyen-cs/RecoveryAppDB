using Dapper;
using RecoveryAppLibrary.Database;
using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public class UAResultData : IUAResultData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public UAResultData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<UAResultModel> GetUAResultById(int id)
        {
            var result = await _dataAccess.LoadData<UAResultModel, dynamic>("sp_UAResultById", new { Id = id }, _connectionString.SqlConnectionName);

            return result.FirstOrDefault();
        }

        public async Task<UAResultModel> GetUAResultByTenantId(int tenantId)
        {
            var result = await _dataAccess.LoadData<UAResultModel, dynamic>("sp_UAResultByTenantId", new { Id = tenantId }, _connectionString.SqlConnectionName);

            return result.FirstOrDefault();
        }

        public async Task<List<UAResultModel>> GetUAResultByDate(DateTime testDate)
        {
            return await _dataAccess.LoadData<UAResultModel, dynamic>("sp_UAResultByDate", new { Date = testDate }, _connectionString.SqlConnectionName);

        }


        public Task<int> UpdateUAResult(int tenantId, Boolean result, DateTime testDate, int id)
        {
            return _dataAccess.SaveData("sp_UAResultUpdate", new { TenantId = tenantId, Id = id, Result = result, TestDate = testDate }, _connectionString.SqlConnectionName);

        }

        public async Task<int> CreateUAResult(int tenantId, Boolean result, DateTime testDate, int id)
        {

            DynamicParameters p = new DynamicParameters();
            p.Add("TenantId", tenantId);
            p.Add("Result", result);
            p.Add("TestDate", testDate);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("sp_UAResultInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

    }
}
