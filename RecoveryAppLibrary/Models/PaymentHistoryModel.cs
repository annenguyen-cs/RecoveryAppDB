using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class PaymentHistoryModel
    {
        public int Id { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PaymentType { get; set; }
        public int TenantId { get; set; }

        public virtual TenantModel Tenant { get; set; }
    }
}
