using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using The2r.Models;
using The2r.Dtos;

namespace The2r.Controllers.Api
{
    [Authorize]
    public class AccountsController : ApiController
    {
        private ApplicationDbContext _context;

        public AccountsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPut]
        public IHttpActionResult UpdateNotifications(string userId, string email)
        {
            ApplicationUser user = _context.Users.Where(c => c.Id == userId).FirstOrDefault();
            if(user.Email == email)
            {
                user.SubscribeToEmail = !user.SubscribeToEmail;
            }
            else
            {
                return BadRequest();
            }
            _context.SaveChanges();
            return Ok(user.SubscribeToEmail);
        }

    }
}
