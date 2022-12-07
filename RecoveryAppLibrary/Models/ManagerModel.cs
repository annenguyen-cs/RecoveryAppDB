using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class ManagerModel
    {
       
        public ManagerModel() 
        {
            this.Tenants = new HashSet<TenantModel>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Boolean TempDelete { get; set; }
        public DateTime TempDeleteDate { get; set; }
        public int OrganizationId { get; set; }



        public virtual OrganizationModel Organization { get; set; }

        public virtual ICollection<TenantModel> Tenants { get;set; }



    }
}
