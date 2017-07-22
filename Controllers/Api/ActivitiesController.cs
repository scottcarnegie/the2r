using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using The2r.Models;
using The2r.Dtos;
using AutoMapper;

namespace The2r.Controllers.Apis
{
    [Authorize]
    public class ActivitiesController : ApiController
    {
        private ApplicationDbContext _context;
        
        public ActivitiesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetActivities()
        {
            IEnumerable<ActivityDto> activityDtoList = _context.Activities.Include(b => b.ApplicationUser).Include(c => c.ActivityType).Where(d => d.IsActive == true).ToList().Select(Mapper.Map<Activity,ActivityDto>);
            return Ok(activityDtoList);
        }

        public IHttpActionResult GetActivities(int Id)
        {
            Activity activity = _context.Activities.FirstOrDefault(a => a.Id == Id);
            return Ok(Mapper.Map<Activity, ActivityDto>(activity));
        }

        [HttpPost]
        public IHttpActionResult CreateActivity(ActivityDto activityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                Activity activity = Mapper.Map<ActivityDto, Activity>(activityDto);
                _context.Activities.Add(activity);
                _context.SaveChanges();
                activityDto.Id = activity.Id;
                return Created(new Uri(Request.RequestUri + "/" + activity.Id),activityDto);
            }
        }

        [HttpPut]
        public void UpdateActivity(int id,ActivityDto activityDto)
        {
            Activity activity = _context.Activities.FirstOrDefault(c => c.Id == id);
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else if( activity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                Mapper.Map(activityDto, activity);
                _context.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteActivity(int id, string username)
        {
            Activity activity = _context.Activities.Include(c => c.ApplicationUser).FirstOrDefault(c => c.Id == id);
            List<Enrollment> enrollments = _context.Enrollments.Where(c => c.ActivityId == id).ToList();

            if(activity == null || activity.ApplicationUser.UserName != username)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                activity.IsActive = false;
                foreach(Enrollment enrollment in enrollments)
                {
                    enrollment.IsActive = false;
                }
                _context.SaveChanges();
            }
        }

    }
}
