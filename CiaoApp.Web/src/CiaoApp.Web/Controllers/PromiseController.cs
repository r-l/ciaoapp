using CiaoApp.Web.ViewModels.Promises;
using System.Collections.Generic;
using System.Threading.Tasks;
using CiaoApp.Web.Models.Promises;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CiaoApp.Web.Models;
using CiaoApp.Web.Services.Persistence;
using CiaoApp.Web.Mappers;
using CiaoApp.Web.ViewModels.Associations;
using CiaoApp.Web.Models.Promises.Associations;

namespace CiaoApp.Web.Controllers
{
    [Authorize]
    public class PromiseController : BaseController
    {
        private readonly IPromiseAccess _promiseAccess;
        private readonly IMessageAccess _messageAccess;
        private readonly IOfferAccess _offerAccess;
        private readonly IAssociationAccess _associationAccess;


        public PromiseController(
            UserManager<ApplicationUser> userManager,
            IPromiseAccess dataAccess,
            IActorAccess actorAccess,
            IMessageAccess messageAccess,
            IOfferAccess offerAccess,
            IAssociationAccess associationAccess,
            ILoggerFactory loggerFactory)
            : base(userManager, loggerFactory, actorAccess)
        {
            _promiseAccess = dataAccess;
            _offerAccess = offerAccess;
            _messageAccess = messageAccess;
            _associationAccess = associationAccess;
        }

        //
        // GET: /Promise/All
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var user = await GetCurrentUserAsync();
            var allPromises = _promiseAccess.GetAllActorPromises(user.Actor);
            var viewModel = new AllPromisesViewModel { AllPromises = new List<PromiseSimpleViewModel>() };
            foreach (var promise in allPromises)
            {
                viewModel.AllPromises.Add(promise.MapToPromiseSimpleView());
            }
            return View(viewModel);
        }

        // GET: /Promise/New
        [HttpGet]
        public IActionResult New()
        {
            return View(new NewRequestViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> FromOffer(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var user = await GetCurrentUserAsync();
            var offer = _offerAccess.LoadOfferById(id);
            if (offer == null)
            {
                return BadRequest();
            }
            if (_offerAccess.IsOfferedToActor(offer, user.Actor, false))
            {
                return View("New", new NewRequestViewModel { Executor = offer.Offerer.GetFullName(), ExecutorId = offer.Offerer.Id, Product = offer.Product, OriginalOfferId = id });
            }
            else
            {
                ViewBag.ErrorTitle = "Cannot take the offer.";
                ViewBag.ErrorText = "The offer is not available to you.";
                return View("Error");
            }

        }

        // POST: /Promise/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(NewRequestViewModel model)
        {
            _logger.LogDebug("New Request: Selected actor id is " + model.ExecutorId);
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                var executor = (model.ExecutorId < 0) ? user.Actor : await _actorAccess.GetActorByIdAsync(model.ExecutorId);
                //TODO Get right status (enable saving)
                var state = new PromiseState { Status = TransactionStatus.Requested, Attained = System.DateTime.Now };
                var promise = new Promise
                {
                    Initiator = user.Actor,
                    Executor = executor,
                    Product = model.Product,
                    Term = model.Term,
                    TermType = model.TermType,
                    States = new List<PromiseState> { state }
                };
                _promiseAccess.SavePromise(promise);
                if (model.OriginalOfferId > 0)
                {
                    _associationAccess.AddAssociation(model.OriginalOfferId.GetValueOrDefault(), promise.Id, AssociationType.IsOriginOf, null);
                }
                _logger.LogInformation("New request was created by " + user.Actor.GetFullName() + " to " + executor.GetFullName() + ". Id of the promise is " + promise.Id.ToString());
                return RedirectToAction(nameof(PromiseController.All), "Promise");

            }

            return View(model);
        }

        // GET: /Promise/Detail
        [HttpGet]
        public async Task<IActionResult> Detail(int id = 0)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var promise = _promiseAccess.LoadPromiseById(id);

            if (promise == null)
            {
                return BadRequest();
            }

            var user = await GetCurrentUserAsync();

            if (promise.Executor.Id != user.ActorId && promise.Initiator.Id != user.ActorId)
            {
                ViewBag.ErrorTitle = "Cannot display the promise.";
                ViewBag.ErrorText = "You are neither the initiator nor the executor of this promise.";
                return View("Error");
            }

            _logger.LogDebug("Loading action detail " + id + ". Available actions: ");
            foreach (var action in promise.GetAllowedActions(user.Actor))
            {
                _logger.LogDebug(action.MapToActionView().Label);
                _logger.LogDebug(action.MapToActionView().Type);
            }
            var messages = _messageAccess.GetAllMessagesForPromise(id);
            return View(promise.MapToPromiseDetailView(user.Actor, messages));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewMessage([FromForm]int Id, [FromForm]string message)
        {
            if (message != null && message.Length > 0)
            {
                var user = await GetCurrentUserAsync();
                _messageAccess.AddNewMessageToPromise(user.Actor, Id, Models.Messages.MessageType.GeneralPromiseDiscussion, message);
            }
            return RedirectToAction("Detail", new { id = Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewAssociation(NewAssociationViewModel model)
        {
            _associationAccess.AddAssociation(model.CreatingPromiseId, model.TargetPromiseId, model.Type, model.TargetState);
            return RedirectToAction("Detail", new { id = model.CreatingPromiseId });
        }

        // POST: /Promise/Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Execute(int ID = 0, string actionName = "")
        {
            _logger.LogDebug("Execute action on promise: " + ID + ". Action name is: " + actionName);
            if (ID == 0 || actionName == "")
            {
                return BadRequest();
            }

            var promise = _promiseAccess.LoadPromiseById(ID);
            if (promise == null)
            {
                return BadRequest();
            }

            var user = await GetCurrentUserAsync();
            var action = promise.GetAllowedActions(user.Actor).Where(act => act.GetActionType() == actionName).FirstOrDefault();
            if (action == null)
            {
                return BadRequest();
            }

            if (action.Execute())
            {
                _promiseAccess.SavePromise(promise);
                var originId = promise.GetOriginId();
                if (originId != null)
                {
                    var idsForCreation = _offerAccess.LoadOfferById(originId.GetValueOrDefault()).GetCreatedPromisesForState(promise.GetCurrentState().Status);
                    foreach (var id in idsForCreation)
                    {
                        var offer = _offerAccess.LoadOfferById(id);
                        if (_offerAccess.IsOfferedToActor(offer, promise.Initiator, true))
                        {
                            var state = new PromiseState { Status = TransactionStatus.Requested, Attained = System.DateTime.Now };
                            var createdPromise = new Promise
                            {
                                Initiator = promise.Executor,
                                Executor = promise.Initiator,
                                Product = offer.Product,
                                Term = promise.Term,
                                TermType = promise.TermType,
                                States = new List<PromiseState> { state }
                            };
                            _promiseAccess.SavePromise(createdPromise);                            
                            _associationAccess.AddAssociation(offer.Id, createdPromise.Id, AssociationType.IsOriginOf, null);                          

                        }
                    }
                    
                }
            }            
            return RedirectToAction(nameof(PromiseController.All), "Promise");
        }
    }
}
