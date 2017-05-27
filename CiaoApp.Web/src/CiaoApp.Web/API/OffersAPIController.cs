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
    public class OffersController : BaseController
    {        
        private readonly IContactAccess _contactAccess;
        private readonly IOfferAccess _offerAccess;

        public OffersController(
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory,
            IActorAccess actorAccess,
            IContactAccess contactAccess,
            IOfferAccess offerAccess) 
            : base(userManager, loggerFactory, actorAccess)
        {
            _contactAccess = contactAccess;
            _offerAccess = offerAccess;
        }

        // GET api/values
        [HttpGet]
        public async Task<JsonResult> SearchOffers(string prefix)
        {
            var user = await GetCurrentUserAsync();
            if (prefix == null)
            {
                prefix = "";
            }
            var offers = _offerAccess.SearchAllActorOffers(user.Actor, prefix).Select(offer => new { label = "Offer " + offer.Id + ": " + offer.Product, id = offer.Id }).ToList();
            return Json(offers);
        }
       
    }
}
