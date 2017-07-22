using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace The2r.Dtos
{
    public class SubscriptionDto
    {
        public byte id { get; set; }
        public string name { get; set; }
        public bool isSubscribed { get; set; }
    }
}