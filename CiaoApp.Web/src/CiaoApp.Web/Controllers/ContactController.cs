using CiaoApp.Web.Mappers;
using CiaoApp.Web.Models;
using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Services.Persistence;
using CiaoApp.Web.ViewModels.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CiaoApp.Web.Controllers
{
    [Authorize]
    public class ContactController : BaseController
    {        
        private readonly IContactAccess _contactAccess;

        public ContactController(
            UserManager<ApplicationUser> userManager,
            ILoggerFactory loggerFactory,
            IActorAccess actorAccess,
            IContactAccess contactAccess)
            : base(userManager, loggerFactory, actorAccess)
        {
            _contactAccess = contactAccess;
        }
        //
        // GET: /Contact/All
        [HttpGet]
        public IActionResult All()
        {
            var user = GetCurrentUserAsync().Result;
            var contactGroups = _contactAccess.GetUserContactGroups(user.Actor.Id).Select(group => group.MapToView()).ToList();
            return View(new AllContactGroupsViewModel { AllContactGroups = new List<ContactGroupViewModel>(contactGroups) });
        }

        //
        // GET: /Contact/NewContact        
        [HttpGet]
        public IActionResult NewContact()
        {
            return View();
        }

        //
        // POST: /Contact/NewContact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewContact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                int actorId;
                var user = GetCurrentUserAsync().Result;
                if (model.IsVirtual)
                {
                    var newVirtualActor = new Actor { IsVirtual = true, LastName = model.Nickname };
                    actorId = _actorAccess.SaveActor(newVirtualActor).Id;
                }
                else
                {
                    actorId = int.Parse(model.ActorId);
                }
                _contactAccess.CreateNewContact(user.ActorId, actorId, model.Nickname);
                return RedirectToAction("All");
            }

            return View("NewContact", model);
        }

        //
        // GET: /Contact/NewContactGroup       
        [HttpGet]
        public IActionResult NewContactGroup()
        {
            return View();
        }

        //
        // POST: /Contact/NewContactGroup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewContactGroup(NewContactGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = GetCurrentUserAsync().Result;                
                _contactAccess.CreateNewContactGroup(user.ActorId, model.name);
                return RedirectToAction("All");
            }

            return View("NewContactGroup", model);
        }
    }
}
