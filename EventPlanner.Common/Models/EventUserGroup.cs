using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Common.Models
{
    public class EventUserGroup
    {
        public string EventUserGroupID { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

        [ForeignKey("Event")]
        public Guid EventID { get; set; }
      
        public virtual User User { get; set; }       
        public virtual Event Event { get; set; }

    }
}
