using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using CiaoApp.Web.Services.Persistence;
using CiaoApp.Web.Models;
using CiaoApp.Web.Controllers;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CiaoApp.Web.API
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PeopleController : BaseController
    {

        private readonly IContactAccess _contactAccess;

        public PeopleController(
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory,
            IActorAccess actorAccess,
            IContactAccess contactAccess) 
            : base(userManager, loggerFactory, actorAccess)
        {
            _contactAccess = contactAccess;
        }


        // GET api/People/GetContacts
        [HttpGet]
        public JsonResult GetContacts(string prefix)
        {
            var user = GetCurrentUserAsync();
             user.Wait();
            _logger.LogDebug("Received API request: GET on /api/People/GetContacts with prefix " + prefix + ". User ID is " + user.Result.Actor.Id);
            var contacts = _contactAccess.GetUserContacts(user.Result.Actor.Id, prefix).Select(act => new { label = act.GetFullName(true), id = act.Id }).ToList();
            contacts.Add(new { label = "myself", id = -1 });
            return Json(contacts);
        }
                
    }
}
