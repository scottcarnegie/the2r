using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using The2r.Models;

namespace The2r.Models
{
    public class ActivityUpdateViewModel
    {
        public Activity activity { get; set; }
        public List<ActivityType> activityTypes { get; set; }
    }
}