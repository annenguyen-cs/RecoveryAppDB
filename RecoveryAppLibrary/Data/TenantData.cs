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
    public class TenantData : ITenantData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public TenantData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<TenantModel>> GetTenantAll()
        {
            return _dataAccess.LoadData<TenantModel, dynamic>("dbo.sp_TenantAll", new { }, _connectionString.SqlConnectionName);
        }

        public Task<List<TenantModel>> GetTenantAllByOrg(int orgId)
        {
            return _dataAccess.LoadData<TenantModel, dynamic>("dbo.sp_TenantAll", new { Id = orgId }, _connectionString.SqlConnectionName);
        }


        public async Task<TenantModel> GetTenantById(int tenantId)
        {
            var tenantRecord = await _dataAccess.LoadData<TenantModel, dynamic>("sp_TenantById", new { Id = tenantId }, _connectionString.SqlConnectionName);

            return tenantRecord.FirstOrDefault();
        }

        public Task<List<TenantModel>> GetTenantByManager(int managerId)
        {
            return _dataAccess.LoadData<TenantModel, dynamic>("sp_TenantByManager", new { Id = managerId }, _connectionString.SqlConnectionName);

        }
        public async Task<int> CreateTenant(TenantModel tenant)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("FirstName", tenant.FirstName);
            p.Add("LastName", tenant.LastName);
            p.Add("Email", tenant.Email);
            p.Add("Phone", tenant.Phone);
            p.Add("ManagerId", tenant.ManagerId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.sp_TenantInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateTenant(int tenantId, string firstName, string lastName, string email, string phone, int managerId)
        {
            return _dataAccess.SaveData("dbo.sp_TenantUpdate", new
            {
                Id = tenantId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                ManagerId = managerId
            }, _connectionString.SqlConnectionName);


        }

        public Task<int> TenantDeactivate(int tenantId)
        {
            return _dataAccess.SaveData("dbo.sp_TenantTempDelete", new { Id = tenantId }, _connectionString.SqlConnectionName);

        }

        public Task<int> TenantReactivate(int tenantId)
        {
            return _dataAccess.SaveData("dbo.sp_TenantReactivate", new { Id = tenantId }, _connectionString.SqlConnectionName);

        }






    }
}
