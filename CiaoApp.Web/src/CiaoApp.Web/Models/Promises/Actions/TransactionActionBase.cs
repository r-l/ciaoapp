using CiaoApp.Web.Models.Actors;
using System;
using System.Collections.Generic;

namespace CiaoApp.Web.Models.Promises.Actions
{
    public abstract class TransactionActionBase
    {
        protected Promise _promise;
        protected Actor _actor;

        public abstract bool IsActorEligible();        
        public abstract ActorRole GetActionActorRole();
        public abstract string GetActionName();
        protected abstract void ActionLogic();

        public string GetActionType()
        {
            return this.GetType().Name;
        }

        public bool Execute()
        {
            if (PromiseIsSet() && IsActorEligible())
            {
                ActionLogic();
                return true;
            }
            return false;
        }

        public void RegisterPromise(Promise promise, Actor actor)
        {
            _promise = promise;
            _actor = actor;
        }
        
        protected bool CheckEligibility(TransactionStatus expectedState, ActorRole expectedRole)
        {

            if ((PromiseIsSet()) && (_promise.GetCurrentState() != null) && (_promise.GetCurrentState().Status == expectedState) && (GetActorRolesForPromise().Contains(expectedRole)))
            {
                return true;
            }
            return false;
        }

        protected void NewState(TransactionStatus status)
        {
            _promise.States.Add(new PromiseState { Attained = DateTime.Now, Promise = _promise, PromiseID = _promise.Id, Status = status });
        }

        private bool PromiseIsSet()
        {
            return (_promise == null) ? false : true;
        }        

        private HashSet<ActorRole> GetActorRolesForPromise()
        {
            var roles = new HashSet<ActorRole>();
            //TODO Not every promise can by viewed by everybody
            roles.Add(ActorRole.Viewer);
            if (_actor != null && PromiseIsSet())
            {
                if ((_promise.Initiator != null) && ((_promise.Initiator.Id == _actor.Id) || ((_promise.Executor != null) && (_promise.Executor.Id == _actor.Id) && (_promise.Initiator.IsVirtual))))
                {
                    roles.Add(ActorRole.Initiator);
                }
                if ((_promise.Executor != null) && ((_promise.Executor.Id == _actor.Id) || ((_promise.Initiator != null) && (_promise.Initiator.Id == _actor.Id) && (_promise.Executor.IsVirtual))))
                {
                    roles.Add(ActorRole.Executor);
                }
            }
            return roles;
        }
    }
}