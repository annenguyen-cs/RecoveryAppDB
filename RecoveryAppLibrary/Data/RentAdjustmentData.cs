using Dapper;
using RecoveryAppLibrary.Database;
using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public class RentAdjustmentData : IRentAdjustmentData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public RentAdjustmentData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;

        }

        public Task<List<RentAdjustmentModel>> GetRentAdjustmentAll()
        {
            return _dataAccess.LoadData<RentAdjustmentModel, dynamic>("sp_RentAdjustmentAll", new { }, _connectionString.SqlConnectionName);

        }

        public async Task<RentAdjustmentModel> GetRentAdjustmentById(int id)
        {
            var rAdjustment = await _dataAccess.LoadData<RentAdjustmentModel, dynamic>("sp_RentAdjustmentById", new { Id = id }, _connectionString.SqlConnectionName);

            return rAdjustment.FirstOrDefault();
        }

        public async Task<RentAdjustmentModel> GetRentAdjustmentByTenantId(int tenantId)
        {
            var tenantRentAdjustment = await _dataAccess.LoadData<RentAdjustmentModel, dynamic>("sp_RentAdjustmentByTenantId", new { Id = tenantId }, _connectionString.SqlConnectionName);

            return tenantRentAdjustment.FirstOrDefault();
        }

        public async Task<int> CreateRentAdjustment(decimal rentAmount, DateTime adjustmentDate, int tenantId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("RentAmount", rentAmount);
            p.Add("AdjustmentDate", adjustmentDate);
            p.Add("TenantId", tenantId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("sp_RentAdjustmentInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateRentAdjustment(int id, decimal rentAmount, DateTime adjustmentDate, int tenantId)
        {
            return _dataAccess.SaveData("sp_RentAdjustmentUpdate", new { Id = id, RentAmount = rentAmount, AdjustmentDate = adjustmentDate, TenantId = tenantId }, _connectionString.SqlConnectionName);
        }

    }
}
