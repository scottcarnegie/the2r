using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace The2r.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public bool IsActive { get; set; }
    }
}