using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using CiaoApp.Web.Services.Persistence;
using CiaoApp.Web.Models;
using CiaoApp.Web.Controllers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CiaoApp.Web.API
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PromisesController : BaseController
    {        
        private readonly IContactAccess _contactAccess;
        private readonly IPromiseAccess _promiseAccess;

        public PromisesController(
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory,
            IActorAccess actorAccess,
            IContactAccess contactAccess,
            IPromiseAccess promiseAccess) 
            : base(userManager, loggerFactory, actorAccess)
        {
            _contactAccess = contactAccess;
            _promiseAccess = promiseAccess;
        }

        // GET api/values
        [HttpGet]
        public async Task<JsonResult> SearchPromises(string prefix)
        {
            var user = await GetCurrentUserAsync();
            if (prefix == null)
            {
                prefix = "";
            }
            var promises = _promiseAccess.SearchAllActorPromises(user.Actor, prefix).Select(prm => new { label = "Promise " + prm.Id + ": " + prm.Product, id = prm.Id }).ToList();
            return Json(promises);
        }
       
    }
}
