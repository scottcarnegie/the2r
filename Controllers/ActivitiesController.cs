using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using The2r.Models;
using The2r.Dtos;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace The2r.Controllers
{
    [Authorize]
    public class ActivitiesController : Controller
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

        public ActionResult Index()
        {
            var UId = User.Identity.GetUserId();
            var viewModel = new ActivitiesViewModel {
                User = _context.Users.FirstOrDefault(c => c.Id == UId)
            };
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new ActivityUpdateViewModel {
                activity = new Activity { CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now, ApplicationUserId = User.Identity.GetUserId(), IsActive = true, CurrentEnrollment = 0, MinimumAttendees = 0, MaximumAttendees = 0, Difficulty = 0 },
                activityTypes = _context.ActivityTypes.ToList()                
            };

            return View("Contribute",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new ActivityUpdateViewModel
            {
                activity = _context.Activities.Include(c => c.ActivityType).Include(d => d.ApplicationUser).FirstOrDefault(f => f.Id == id),
                activityTypes = _context.ActivityTypes.ToList()
            };

            viewModel.activity.ModifiedOn = DateTime.Now;

            if (viewModel.activity.ApplicationUser == null || (viewModel.activity.ApplicationUser.Id != User.Identity.GetUserId()))
            {
                return new HttpNotFoundResult("Are you the owner?");
            }

            return View("Contribute", viewModel);
        }

        public ActionResult Details(int id)
        {
            string cUserId = User.Identity.GetUserId();

            EnrollmentDto enrollment = _context.Enrollments.Where(c => c.ActivityId == id && c.ApplicationUserId == cUserId).Select(Mapper.Map<Enrollment,EnrollmentDto>).FirstOrDefault();

            if (enrollment == null)
            {
               enrollment = new EnrollmentDto { Id = 0, ActivityId = id, ApplicationUserId = User.Identity.GetUserId(), IsActive = true };
            }
            var viewModel = new ActivityDetailsViewModel { Activity = _context.Activities.Include(c => c.ActivityType).Include(d => d.ApplicationUser).Select(Mapper.Map<Activity,ActivityDto>).FirstOrDefault(f => f.Id == id),
            Enrollment = enrollment};

            return View(viewModel);
        }


    }
}