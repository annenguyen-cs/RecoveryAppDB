using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class PreferredHospitalModel
    {
        public int Id { get; set; }

        public string  HospitalName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int TenantId { get; set; }

        public virtual TenantModel Tenant { get; set; }
    }
}
