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
    public class TenantDetailsData : ITenantDetailsData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public TenantDetailsData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<TenantDetailsModel> GetTenantDetailByTenantId(int tenantId)
        {
            var tenantDetail = await _dataAccess.LoadData<TenantDetailsModel, dynamic>("sp_TenantDetailsByTenantId", new { Id = tenantId }, _connectionString.SqlConnectionName);

            return tenantDetail.FirstOrDefault();
        }
        public async Task<int> CreateTenantDetail(int tenantId, Boolean depositPaid, DateTime intakeDate, Boolean rentalStatus, decimal rentAmount, decimal finesBalance)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("TenantId", tenantId);
            p.Add("DepositPaid", depositPaid);
            p.Add("IntakeDate", intakeDate);
            p.Add("RentalStatus", rentalStatus);
            p.Add("RentAmount", rentAmount);
            p.Add("FinesBalance", finesBalance);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.sp_TenantDetailsInsert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public Task<int> UpdateTenantDetail(int tenantId, Boolean depositPaid, DateTime intakeDate, Boolean rentalStatus, decimal rentAmount, decimal finesBalance)
        {
            return _dataAccess.SaveData("dbo.sp_TenantDetailsUpdate", new
            {
                TenantId = tenantId,
                DepositPaid = depositPaid,
                IntakeDate = intakeDate,
                RentalStatus = rentalStatus,
                RentAmount = rentAmount,
                FinesBalance = finesBalance
            }, _connectionString.SqlConnectionName);
        }


    }
}
