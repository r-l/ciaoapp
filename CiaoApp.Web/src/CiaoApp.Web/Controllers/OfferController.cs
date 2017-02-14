using CiaoApp.Web.Mappers;
using CiaoApp.Web.Models;
using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.Services.Persistence;
using CiaoApp.Web.ViewModels.Associations;
using CiaoApp.Web.ViewModels.Offers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiaoApp.Web.Controllers
{
    [Authorize]
    public class OfferController : BaseController
    {
        private readonly IOfferAccess _offerAccess;
        private readonly IContactAccess _contactAccess;

        public OfferController(
            UserManager<ApplicationUser> userManager,
            IOfferAccess dataAccess,
            IActorAccess actorAccess,
            ILoggerFactory loggerFactory,
            IContactAccess contactAccess)
            : base(userManager, loggerFactory, actorAccess)
        {
            _offerAccess = dataAccess;
            _contactAccess = contactAccess;
        }

        //
        // GET: /Offer/All
        [HttpGet]
        public async Task<IActionResult> All()
        {

            var user = await GetCurrentUserAsync();
            return View(new AllOffersViewModel { AllOffers = _offerAccess.GetAllOffers(user.Actor) });
        }

        //
        // GET: /Offer/OfferedBy/Id
        [HttpGet]
        public async Task<IActionResult> OfferedBy(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var user = await GetCurrentUserAsync();
            var offerer = await _actorAccess.GetActorByIdAsync(id);
            var offersForCurrentUser = _offerAccess.GetAllOffersForActor(offerer, user.Actor);
            var offered = new OfferedViewModel { Offers = new List<OfferSimpleViewModel>(), OffererName = offerer.GetFullName(true) };
            foreach (var offer in offersForCurrentUser)
            {
                offered.Offers.Add(offer.MapToSimpleOffer());
            }
            return View(offered);
        }


        // GET: /Offer/New
        [HttpGet]
        public IActionResult New()
        {
            return View(new NewOfferViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> New(NewOfferViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var newOffer = new Offer { Offerer = user.Actor, Product = model.Product, TargetType = model.TargetType };
                if (model.TargetType == OfferTargetType.SelectedContactGroup)
                {
                    newOffer.SelectedContactGroupId = model.TargetContactGroupId;
                } else if (model.TargetType == OfferTargetType.AllContacts)
                {
                    newOffer.SelectedContactGroupId = _contactAccess.GetDefaultContactGroup(user.Actor.Id).Id;
                }
                _offerAccess.SaveOffer(newOffer);
                return RedirectToAction(nameof(OfferController.All), "Offer");
            }
            return View(model);
        }

        // GET: /Offer/New
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var offer = _offerAccess.LoadOfferById(id);

            if (offer == null)
            {
                return BadRequest();
            }

            var user = await GetCurrentUserAsync();

            if (offer.Offerer.Id != user.ActorId)
            {
                ViewBag.ErrorTitle = "Cannot display the offer.";
                ViewBag.ErrorText = "You are not the offerer.";
                return View("Error");
            }

            return View(new OfferViewModel { AllAssociations = new AllAssociationsViewModel { AllAssociations = new List<AssociationViewModel>(), NewAssociation = new NewAssociationViewModel { Context = AssociationContext.Offer } } });
        }
    }
}
