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
    public class ContactsController : BaseController
    {        
        private readonly IContactAccess _contactAccess;

        public ContactsController(
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory,
            IActorAccess actorAccess,
            IContactAccess contactAccess) 
            : base(userManager, loggerFactory, actorAccess)
        {
            _contactAccess = contactAccess;
        }

        // GET api/values
        [HttpGet]
        public JsonResult GetContactGroups(string prefix)
        {
            var user = GetCurrentUserAsync();
            user.Wait();
            _logger.LogDebug("Received API request: GET on /api/Contacts/GetContactGroups with prefix " + prefix + ". User ID is " + user.Result.Actor.Id);
            var contactGroups = _contactAccess.GetUserContactGroups(user.Result.Actor.Id).Select(group => new { label = group.Name, id = group.Id }).ToList();
            return Json(contactGroups);
        }
       
    }
}
