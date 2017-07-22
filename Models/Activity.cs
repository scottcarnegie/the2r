using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace The2r.Models
{
    public class Activity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public byte Difficulty { get; set; }
        [Display(Name = "Minimum Enrollment")]
        public byte? MinimumAttendees { get; set; }

        [Display(Name = "Maximum Enrollment")]
        public int? MaximumAttendees { get; set; }

        public int? CurrentEnrollment { get; set; }

        [Display (Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        [Display (Name = "Activity Date")]
        public DateTime? EventStart { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string MapUrl { get; set; }
        public string PlaceId { get; set; }
        public ActivityType ActivityType { get; set; }
        [Display (Name = "Activity Type")]
        public byte? ActivityTypeId { get; set; }
        public bool IsActive { get; set; }

    }
}