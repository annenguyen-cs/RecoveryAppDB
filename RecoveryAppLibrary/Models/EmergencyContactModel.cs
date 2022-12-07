using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class EmergencyContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Relationship { get; set; }
        public int TenantId { get; set; }

        public virtual TenantModel Tenant { get; set; }
    }
}
