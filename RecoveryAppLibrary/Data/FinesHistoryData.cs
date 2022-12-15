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
    public class FinesHistoryData : IFinesHistoryData
    {
        private readonly IDataAccess _accessData;
        private readonly ConnectionStringData _connectionData;

        public FinesHistoryData(IDataAccess accessData, ConnectionStringData connectionString)
        {
            _accessData = accessData;
            _connectionData = connectionString;
        }

        public Task<List<FinesHistoryModel>> GetFinesHistoryAll()
        {
            return _accessData.LoadData<FinesHistoryModel, dynamic>("sp_FinesHistoryAll", new { }, _connectionData.SqlConnectionName);
        }

        public async Task<FinesHistoryModel> GetFinesHistoryById(int id)
        {
            var fines = await _accessData.LoadData<FinesHistoryModel, dynamic>("sp_FinesHistoryById", new { Id = id }, _connectionData.SqlConnectionName);

            return fines.FirstOrDefault();
        }

        public async Task<FinesHistoryModel> GetFinesHistoryByTenantId(int tenantId)
        {
            var fineByTenant = await _accessData.LoadData<FinesHistoryModel, dynamic>("sp_FinesHistoryByTenantId", new { Id = tenantId }, _connectionData.SqlConnectionName);

            return fineByTenant.FirstOrDefault();
        }

        public async Task<int> CreateFinesHistory(int tenantId, Boolean fromBalance, decimal amount, DateTime transactionDate)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("TenantId", tenantId);
            p.Add("FromBalance", fromBalance);
            p.Add("Amount", amount);
            p.Add("TranscationDate", transactionDate);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _accessData.SaveData("sp_FinesHistoryInsert", p, _connectionData.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> FineHistoryUpdate(int id, int tenantId, Boolean fromBalance, decimal amount, DateTime transactionDate)
        {
            return _accessData.SaveData("sp_FinesHistoryUpdate", new { Id = id, TenantId = tenantId, FromBalance = fromBalance, Amount = amount, TransactionDate = transactionDate }, _connectionData.SqlConnectionName);
        }
    }
}
