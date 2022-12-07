using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class UAResultModel
    {

        public UAResultModel() 
        {
            this.UAFollowUps = new HashSet<UAFollowUpModel>();
        }

        public int Id { get; set; }
        public Boolean Result { get; set; }
        public DateTime TestDate { get; set; } 
        public int TenantId { get; set; }

        public virtual TenantModel Tenant { get; set; }

        public virtual ICollection<UAFollowUpModel> UAFollowUps { get; set; }
    }
}
