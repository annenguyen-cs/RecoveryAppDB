using System;
using System.Collections.Generic;
using System.Text;

namespace RecoveryAppLibrary.Models
{
    public class UAFollowUpModel
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public DateTime FollowUpDate { get; set; }
        public int UAId { get; set; }

        public virtual UAResultModel UAResult { get; set; }


    }
}
