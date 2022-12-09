using RecoveryAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Data
{
    public interface IRentAdjustmentData
    {
        Task<int> CreateRentAdjustment(decimal rentAmount, DateTime adjustmentDate, int tenantId);
        Task<List<RentAdjustmentModel>> GetRentAdjustmentAll();
        Task<RentAdjustmentModel> GetRentAdjustmentById(int id);
        Task<RentAdjustmentModel> GetRentAdjustmentByTenantId(int tenantId);
        Task<int> UpdateRentAdjustment(int id, decimal rentAmount, DateTime adjustmentDate, int tenantId);
    }
}