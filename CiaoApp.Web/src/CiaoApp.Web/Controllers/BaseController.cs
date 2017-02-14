using CiaoApp.Web.Models;
using CiaoApp.Web.Services.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CiaoApp.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly ILogger _logger;
        protected readonly IActorAccess _actorAccess;

        public BaseController(
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory,
            IActorAccess actorAccess)
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger(this.GetType().Name);
            _actorAccess = actorAccess;
        }

        #region Helpers       

        protected async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            user.Actor = await _actorAccess.GetActorByIdAsync(user.ActorId);
            return user;
        }

        #endregion
    }
}
