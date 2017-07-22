using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using The2r.Models;

namespace The2r.Dtos
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserDto ApplicationUser { get; set; }
        public int ActivityId { get; set; }
        public ActivityDto Activity { get; set; }
        public bool IsActive { get; set; }
    }
}