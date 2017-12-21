using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Common.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<EventUserGroup> EventUsersGroups { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<DatePreference> DatePreferences { get; set; }

    }
}
