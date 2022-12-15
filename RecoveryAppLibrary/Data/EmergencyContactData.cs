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
    public class EmergencyContactData : IEmergencyContactData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public EmergencyContactData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<EmergencyContactModel> GetEmergencyContactByTenantId(int tenantId)
        {
            var eContact = await _dataAccess.LoadData<EmergencyContactModel, dynamic>("sp_EmergencyContactByTenantId", new { Id = tenantId }, _connectionString.SqlConnectionName);

            return eContact.FirstOrDefault();
        }

        public async Task<int> CreateEmergencyContact(int tenantId, string firstName, string lastName, string relationship, string phone, string email)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("TenantId", tenantId);
            p.Add("FirstName", firstName);
            p.Add("LastName", lastName);
            p.Add("Relationship", relationship);
            p.Add("Phone", phone);
            p.Add("Email", email);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);


            await _dataAccess.SaveData("sp_EmergencyContactInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateEmergencyContact(int id, int tenantId, string firstName, string lastName, string relationship, string phone, string email)
        {
            return _dataAccess.SaveData("sp_EmergencyContactUpdate", new
            {
                Id = id,
                TenantId = tenantId,
                FirstName = firstName,
                LastName = lastName,
                Relationship = relationship,
                Phone = phone,
                Email = email
            }, _connectionString.SqlConnectionName);
        }
    }
}
