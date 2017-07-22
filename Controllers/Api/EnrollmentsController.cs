using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using The2r.Models;
using The2r.Dtos;
using System.Data.Entity;
using AutoMapper;

namespace The2r.Controllers.Api
{
    [Authorize]
    public class EnrollmentsController : ApiController
    {
        private ApplicationDbContext _context;

        public EnrollmentsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetEnrollments()
        {
            List<EnrollmentDto> enrollments = _context.Enrollments.Select(Mapper.Map<Enrollment,EnrollmentDto>).ToList();
            return Ok(enrollments);
        }

        public IHttpActionResult GetEnrollments(string applicationUserId, bool onlyActive)
        {
            List<EnrollmentDto> enrollments;
            if (onlyActive)
            {
                enrollments = _context.Enrollments.Include(c => c.Activity.ActivityType).Where(c => c.ApplicationUserId == applicationUserId && c.IsActive == true).Select(Mapper.Map<Enrollment, EnrollmentDto>).OrderBy(c => c.Activity.EventStart).ToList();
            }
            else
            {
                enrollments = _context.Enrollments.Include(c => c.Activity.ActivityType).Where(c => c.ApplicationUserId == applicationUserId).Select(Mapper.Map<Enrollment, EnrollmentDto>).OrderBy(c => c.Activity.EventStart).ToList();
            }
            return Ok(enrollments);
        }

        [HttpPost]
        public IHttpActionResult CreateEnrollment(EnrollmentDto enrollmentdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                Enrollment enrollment = Mapper.Map<EnrollmentDto, Enrollment>(enrollmentdto);
                _context.Enrollments.Add(enrollment);

                Activity activity = _context.Activities.Where(c => c.Id == enrollment.ActivityId).FirstOrDefault();
                activity.CurrentEnrollment++;

                _context.SaveChanges();
                enrollmentdto.Id = enrollment.Id;
                return Created(new Uri(Request.RequestUri + "/" + enrollmentdto.Id), enrollmentdto);
            }
        }

        [HttpDelete]
        public void DeleteEnrollment(int id, int activityid, string username)
        {
            Enrollment enrollment = _context.Enrollments.Include(c => c.ApplicationUser).FirstOrDefault(c => c.Id == id);
            if (enrollment == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else if (enrollment.ApplicationUser.UserName != username || enrollment.ActivityId != activityid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                enrollment.IsActive = false;
                _context.SaveChanges();
            }
        }

        [HttpPut]
        public void UpdateEnrollment(int id, EnrollmentDto enrollmentDto)
        {
            Enrollment enrollment = _context.Enrollments.FirstOrDefault(c => c.Id == id);
            
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else if (enrollment == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                Mapper.Map(enrollmentDto, enrollment);

                Activity activity = _context.Activities.Where(c => c.Id == enrollment.ActivityId).FirstOrDefault();
                if(enrollment.IsActive == false)
                {
                    activity.CurrentEnrollment--;
                }
                else
                {
                    activity.CurrentEnrollment++;
                }

                _context.SaveChanges();
            }
        }

    }
}
