using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class IncidentFollowUpModel
    {
        public int Id { get; set; }
        public string FollowUpSummary { get; set; }
        public DateTime FollowUpDate { get; set; }
        public int IncidentId { get; set; }

        public virtual IncidentReportModel IncidentReport { get; set; }

    }
}
