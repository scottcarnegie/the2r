using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace The2r.Dtos
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Difficulty { get; set; }
        public byte MinimumAttendees { get; set; }
        public int MaximumAttendees { get; set; }
        public int CurrentEnrollment { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserDto ApplicationUser { get; set; }
        [Display(Name = "Activity Date")]
        public DateTime EventStart { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string MapUrl { get; set; }
        public string PlaceId { get; set; }
        public ActivityTypeDto ActivityType { get; set; }
        public byte ActivityTypeId { get; set; }
        public bool IsActive { get; set; }

    }
}