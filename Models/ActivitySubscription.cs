using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace The2r.Models
{
    public class ActivitySubscription
    {
        [Required]
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        public ActivityType ActivityType { get; set; }
        [Required]
        public byte ActivityTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}