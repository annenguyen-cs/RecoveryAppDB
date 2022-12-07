using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class FinesHistoryModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Boolean FromBalance { get; set; }
        public int TenantId { get; set; }

        public virtual TenantModel Tenant { get; set; } 
    }
}
