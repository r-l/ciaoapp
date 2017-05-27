using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Messages;
using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.ViewModels.Associations;
using CiaoApp.Web.ViewModels.Promises;
using System.Collections.Generic;
using System.Linq;

namespace CiaoApp.Web.Mappers
{
    public static class PromiseMapper
    {
        public static PromiseDetailViewModel MapToPromiseDetailView(this Promise promise, Actor actor, IList<Message> messages = null)
        {
            var initiatorActions = new List<ActionViewModel>();
            var executorActions = new List<ActionViewModel>();
            var simpleMessages = new List<MessageSimpleViewModel>();
            var associations = new List<AssociationViewModel>();

            initiatorActions.AddRange(promise.GetAllowedActions(actor).Where(act => act.GetActionActorRole() == ActorRole.Initiator).Select(act => act.MapToActionView()));
            executorActions.AddRange(promise.GetAllowedActions(actor).Where(act => act.GetActionActorRole() == ActorRole.Executor).Select(act => act.MapToActionView()));
            associations.AddRange(promise.ParentAssociations.Select(assoc => assoc.MapToAssociationView(AssociationKind.Parent)).Concat(promise.ChildAssociations.Select(assoc => assoc.MapToAssociationView(AssociationKind.Child))));

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    simpleMessages.Add(message.MapToSimpleMessage(actor.Id));
                }
            }

            return new PromiseDetailViewModel
            {
                Id = promise.Id,
                CurrentStatus = promise.GetCurrentState().Status,
                ExecutorName = (promise.Executor == null) ? "Not specified" : promise.Executor.GetFullName(true),
                InitiatorName = (promise.Initiator == null) ? "Not specified" : promise.Initiator.GetFullName(true),
                Product = promise.Product,
                Term = promise.Term,
                TermType = promise.TermType,
                InitiatorActions = initiatorActions,
                ExecutorActions = executorActions,
                Messages = simpleMessages,
                AllAssociations = new AllAssociationsViewModel { AllAssociations = associations, NewAssociation = new NewAssociationViewModel(AssociationContext.Promise) { CreatingPromiseId = promise.Id, Context = AssociationContext.Promise} }
            };
        }

        public static PromiseSimpleViewModel MapToPromiseSimpleView(this Promise promise)
        {
            return new PromiseSimpleViewModel
            {
                Id = promise.Id,
                CurrentStatus = promise.GetCurrentState().Status,
                ExecutorName = (promise.Executor == null) ? "Not specified" : promise.Executor.GetFullName(true),
                InitiatorName = (promise.Initiator == null) ? "Not specified" : promise.Initiator.GetFullName(true),
                Product = promise.Product,
                Term = promise.Term,
                TermType = promise.TermType
            };
        }
    }
}
