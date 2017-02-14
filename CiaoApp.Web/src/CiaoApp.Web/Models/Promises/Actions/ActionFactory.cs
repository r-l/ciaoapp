using CiaoApp.Web.Models.Actors;
using System.Collections.Generic;
using System.Linq;

namespace CiaoApp.Web.Models.Promises.Actions
{
    internal class ActionFactory
    {

        public IEnumerable<TransactionActionBase> GetActionsForPromise(Promise promise, Actor actor)
        {
            return RegisterAllActions(promise, actor).Where(a => a.IsActorEligible());
        }

        private TransactionActionBase RegisterAction<TransactionAction>(Promise promise, Actor actor) where TransactionAction : TransactionActionBase, new()
        {
            var action = new TransactionAction();
            action.RegisterPromise(promise, actor);
            return action;
        }

        private IEnumerable<TransactionActionBase> RegisterAllActions(Promise promise, Actor actor)
        {
            var AllActions = new HashSet<TransactionActionBase>();
            AllActions.Add(RegisterAction<AcceptAction>(promise, actor));
            AllActions.Add(RegisterAction<AllowAction>(promise, actor));
            AllActions.Add(RegisterAction<DeclineAction>(promise, actor));
            AllActions.Add(RegisterAction<PromiseAction>(promise, actor));
            AllActions.Add(RegisterAction<QuitAction>(promise, actor));
            AllActions.Add(RegisterAction<RefuseAction>(promise, actor));
            AllActions.Add(RegisterAction<RejectAction>(promise, actor));
            AllActions.Add(RegisterAction<RequestAction>(promise, actor));
            AllActions.Add(RegisterAction<RevokeAcceptAction>(promise, actor));
            AllActions.Add(RegisterAction<RevokePromiseAction>(promise, actor));
            AllActions.Add(RegisterAction<RevokeRequestAction>(promise, actor));
            AllActions.Add(RegisterAction<RevokeStateAction>(promise, actor));
            AllActions.Add(RegisterAction<StateAction>(promise, actor));
            AllActions.Add(RegisterAction<StopAction>(promise, actor));
            return AllActions;
        }
    }
}