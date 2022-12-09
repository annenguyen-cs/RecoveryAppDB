using Dapper;
using RecoveryAppLibrary.Database;
using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public class PreferredHospitalData : IPreferredHospitalData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public PreferredHospitalData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;

        }

        public Task<List<PreferredHospitalModel>> GetPreferredHospitalByTenantId(int tenantId)
        {
            return _dataAccess.LoadData<PreferredHospitalModel, dynamic>("sp_PreferredHospitalByTenantId", new { Id = tenantId }, _connectionString.SqlConnectionName);
        }

        public async Task<int> CreatePreferredHospital(string hospitalName, string street, string city, string zipCode, string phone, int tenantId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("HospitalName", hospitalName);
            p.Add("Street", street);
            p.Add("City", city);
            p.Add("ZipCode", zipCode);
            p.Add("Phone", phone);
            p.Add("TenantId", tenantId);

            await _dataAccess.SaveData("sp_PreferredHospitalInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");

        }

        public Task<int> UpdatePreferredHospital(int id, string hospitalName, string street, string city, string zipCode, string phone, int tenantId)
        {
            return _dataAccess.SaveData("dbo.sp_PreferredHopistalUpdate", new { Id = id, HospitalName = hospitalName, Street = street, City = city, ZipCode = zipCode, Phone = phone, TenantId = tenantId }, _connectionString.SqlConnectionName);
        }
    }
}
