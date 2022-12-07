using Dapper;
using RecoveryAppLibrary.Database;
using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public class ManagerData : IManagerData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public ManagerData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
        /// <summary>
        /// Retrieve all manager records
        /// </summary>
        /// <returns></returns>
        public Task<List<ManagerModel>> GetManagerAll()
        {
            return _dataAccess.LoadData<ManagerModel, dynamic>("dbo.sp_ManagerAll", new { }, _connectionString.SqlConnectionName);
        }
        /// <summary>
        /// retrieve manager record by their Id - if does not exist return null
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        public async Task<ManagerModel> GetManagerById(int managerId)
        {
            var managerRecord = await _dataAccess.LoadData<ManagerModel, dynamic>("dbo.sp_ManagerById", new { Id = managerId }, _connectionString.SqlConnectionName);

            return managerRecord.FirstOrDefault();
        }
        /// <summary>
        /// Insert new manager record 
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public async Task<int> CreateManager(ManagerModel manager)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("FirstName", manager.FirstName);
            p.Add("LastName", manager.LastName);
            p.Add("Email", manager.Email);
            p.Add("Phone", manager.Phone);
            p.Add("OrganizationId", manager.OrganizationId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.sp_ManagerInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");

        }
        /// <summary>
        /// Update manager information in record
        /// </summary>
        /// <param name="managerId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public Task<int> UpdateManager(int managerId, string firstName, string lastName, string email, string phone)
        {
            return _dataAccess.SaveData("dbo.sp_ManagerUpdate", new { Id = managerId, FirstName = firstName, LastName = lastName, Email = email, Phone = phone }, _connectionString.SqlConnectionName);
        }
        /// <summary>
        /// With managerId deactivate account- non admins will not be able to see deactivated managers
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>

        public Task<int> ManagerDeactivate(int managerId)
        {
            return _dataAccess.SaveData("dbo.sp_ManagerTempDelete", new { Id = managerId }, _connectionString.SqlConnectionName);

        }
        /// <summary>
        /// Reactivate manager record if within the conditonal timeline 
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        public Task<int> ManagerReactivate(int managerId)
        {
            return _dataAccess.SaveData("dbo.sp_ManagerReactivate", new { Id = managerId }, _connectionString.SqlConnectionName);
        }




    }
}
