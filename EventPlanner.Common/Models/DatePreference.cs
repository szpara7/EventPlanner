using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Common.Models
{
    public class DatePreference
    {
        public string DatePreferenceID { get; set; }
        [Required]
        public DateTime MinDate{ get;set;}
        [Required]
        public DateTime MaxDate { get; set; }

        [ForeignKey("Event")]
        public Guid EventID { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
