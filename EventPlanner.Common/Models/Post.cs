using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Common.Models
{
    public class Post
    {
        public string PostID { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("Event")]
        public Guid EventID { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; } 
        
        public virtual Event Event { get; set; }      
        public virtual User User { get; set; }

    }
}
