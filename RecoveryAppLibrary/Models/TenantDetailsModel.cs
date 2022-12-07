using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class TenantDetailsModel
    {
        public int Id { get; set; }
        public Boolean DepositPaid { get; set; }
        public DateTime IntakeDate { get; set; }
        public Boolean RentalStatus { get; set; }
        public decimal RentalAmount { get; set; }
        public decimal FinesBalance { get; set; }
        public int TenantId { get; set; }

        public virtual TenantModel Tenant { get; set; }

    }
}
