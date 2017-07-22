using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using The2r.Models;
using The2r.Dtos;
using AutoMapper;

namespace The2r.Controllers.Api
{
    [Authorize]
    public class SubscriptionsController:ApiController
    {
        private ApplicationDbContext _context;

        public SubscriptionsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IHttpActionResult GetSubscriptions(string userId)
        {
            List<SubscriptionDto> subscriptionList = _context.ActivityTypes.Select(Mapper.Map<ActivityType, SubscriptionDto>).ToList();
            List<ActivitySubscription> subscriptions = new List<ActivitySubscription>();
            try
            {
                subscriptions = _context.ActivitySubscription.Where(c => c.ApplicationUserId == userId).ToList();
            }
            catch (Exception) {
            }
            
            foreach(SubscriptionDto s in subscriptionList)
            {
                if (subscriptions.Any(c => c.ActivityTypeId == s.id)) {
                    s.isSubscribed = subscriptions.Where(c => c.ActivityTypeId == s.id).First().IsActive;
                }
                else
                {
                    s.isSubscribed = true;
                }
            }

            return Ok(subscriptionList);
        }

        public IHttpActionResult UpdateSubscriptions(string userId, List<SubscriptionDto> activitySubscriptions )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                List<ActivitySubscription> subscriptions = new List<ActivitySubscription>();
                try
                {
                    subscriptions = _context.ActivitySubscription.Where(c => c.ApplicationUserId == userId).ToList();
                }
                catch (Exception)
                {
                }

                foreach (SubscriptionDto s in activitySubscriptions)
                {
                    if (subscriptions.Any(c => c.ActivityTypeId == s.id))
                    {
                        subscriptions.Where(c => c.ActivityTypeId == s.id).First().IsActive = s.isSubscribed;        
                    }
                    else
                    {
                        _context.ActivitySubscription.Add(new ActivitySubscription { Id = 0, ApplicationUserId = userId, ActivityTypeId = s.id, IsActive = s.isSubscribed });
                    }
                }

                _context.SaveChanges();
                
                return Ok();
            }
        }

    }
}