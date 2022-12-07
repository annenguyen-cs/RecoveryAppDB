using RecoveryAppLibrary.Database;
using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public class TenantData
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
            return  _dataAccess.LoadData<TenantModel, dynamic>("sp_TenantByManager", new { Id = managerId }, _connectionString.SqlConnectionName);

            
        }
 

    }
}
