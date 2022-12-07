using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class TenantModel
    {
      

        public TenantModel()
        {
            this.IncidentReports = new HashSet<IncidentReportModel>();
            this.UAResults = new HashSet<UAResultModel>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ManagerId { get; set; }

        public Boolean TempDelete { get; set; }
        public DateTime TempDeleteDate { get; set; }
        public virtual ManagerModel Manager { get; set; }
        public virtual TenantDetailsModel TenantDetails { get; set; }
        public virtual EmergencyContactModel EmergencyContact { get; set; }
        public virtual PreferredHospitalModel PreferredHospital { get; set; }
        public virtual PaymentHistoryModel PaymentHistory { get; set; }
        public virtual RentAdjustmentModel RentAdjustment { get; set; }
        public virtual FinesHistoryModel FinesHistory { get; set; }

        public virtual ICollection<IncidentReportModel> IncidentReports { get; set; }
        public ICollection<UAResultModel> UAResults { get; set; }





    }
}
