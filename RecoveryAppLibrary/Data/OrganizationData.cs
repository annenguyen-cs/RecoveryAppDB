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

    public class OrganizationData : IOrganizationData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public OrganizationData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        /// <summary>
        /// retrieving all data from organization table - no params
        ///  calling stored prod and pass parameters and connection string to get data from database
        /// </summary>
        public Task<List<OrganizationModel>> GetOrganizationAll()
        {
            return _dataAccess.LoadData<OrganizationModel, dynamic>("dbo.sp_OrganizationAll", new { }, _connectionString.SqlConnectionName);
        }
        /// <summary>
        /// Retrieving an organization record by Organization Id search
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<OrganizationModel> GetOrganizationById(int Id)
        {
            //has async and await here bc awaiting a call to then modify the list that comes back to return the first value
            var orgRecord = await _dataAccess.LoadData<OrganizationModel, dynamic>("dbo.sp_OrganizationById", new { Id }, _connectionString.SqlConnectionName);
            //first (the first record) or default (null)
            return orgRecord.FirstOrDefault();
        }
        /// <summary>
        /// Create organization record and returning Id of new record
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public async Task<int> CreateOrganization(OrganizationModel organization)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Title", organization.Title);
            p.Add("Street", organization.Street);
            p.Add("City", organization.City);
            p.Add("ZipCode", organization.ZipCode);
            //pass id in and will get id data to output 
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.sp_OrganizationInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");

        }
        /// <summary>
        /// Updating Organization title with Id search and updating name/title
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        public Task<int> UpdateOrganizationTitle(int organizationId, string name)
        {
            return _dataAccess.SaveData("dbo.sp_OrganizationUpdateTitle",
                                        new { Id = organizationId, Title = name },
                                        _connectionString.SqlConnectionName);
        }
        /// <summary>
        /// By organization Id - deactivate account 
        /// stored prod adds date of deactivation date
        /// Data will not be retrievable by non admin user
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>

        public Task<int> OrganizationDeactivate(int organizationId)
        {
            return _dataAccess.SaveData("dbo.sp_OrganizationTempDelete",
                                        new { Id = organizationId },
                                        _connectionString.SqlConnectionName);
        }
        /// <summary>
        /// Reactivates Organization by Id if conditional delete by time limit has not been exceeded
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>

        public Task<int> OrganizationReactivate(int organizationId)
        {
            return _dataAccess.SaveData("dbo.sp_OrganizationReactivate",
                                        new { Id = organizationId },
                                        _connectionString.SqlConnectionName);
        }

    }
}
