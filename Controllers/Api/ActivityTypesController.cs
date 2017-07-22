using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using The2r.Models;
using The2r.Dtos;
using AutoMapper;

namespace The2r.Controllers.Api
{
    [Authorize]
    public class ActivityTypesController:ApiController
    {
        private ApplicationDbContext _context;

        public ActivityTypesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetActivityTypes()
        {
            IEnumerable<ActivityType> activityTypes = _context.ActivityTypes.ToList();
            return Ok(activityTypes);
        }
        
    }
}