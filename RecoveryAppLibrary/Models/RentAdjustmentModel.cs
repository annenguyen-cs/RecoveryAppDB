using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class RentAdjustmentModel
    {
        public int Id { get; set; }
        public decimal RentAmount { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public int TenantId { get; set; }

        public virtual TenantModel Tenant { get; set; }
    }
}
