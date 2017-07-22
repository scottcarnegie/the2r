using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using The2r.Dtos;

namespace The2r.Models
{
    public class ActivityDetailsViewModel
    {
        public EnrollmentDto Enrollment { get; set; }
        public ActivityDto Activity { get; set; }
    }
}