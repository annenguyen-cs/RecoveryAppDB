using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class IncidentReportModel
    {
        public IncidentReportModel()
        {
            this.IncidentFollowUps = new HashSet<IncidentFollowUpModel>();
        }
        public int Id { get; set; }
        public string Summary { get; set; }
        public DateTime IncidentDate { get; set; }
        public int TenantId { get; set; }

        public virtual TenantModel Tenant { get; set; }
        public virtual ICollection<IncidentFollowUpModel> IncidentFollowUps { get; set; }
    }
}
