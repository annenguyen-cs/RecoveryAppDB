using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class OrganizationModel
    {

        public OrganizationModel()
        {
            this.ManagerModel = new HashSet<ManagerModel>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Boolean TempDelete { get; set; }
        public DateTime TempDeleteDate { get; set; } 

        public virtual ICollection<ManagerModel> ManagerModel { get; set; }


    }

}
