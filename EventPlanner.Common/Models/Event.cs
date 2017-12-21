using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Common.Models
{
    public class Event
    {
        public Guid EventID { get; set; }
        [Required]
        public string EventName { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime MinDate { get; set; }
        [Required]
        public DateTime MaxDate { get; set; }

        [DefaultValue(false)]
        public bool IsEnded { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public virtual ICollection<DatePreference> DatePreferences { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<EventUserGroup> EventUsersGroup { get; set; }
    }
}
