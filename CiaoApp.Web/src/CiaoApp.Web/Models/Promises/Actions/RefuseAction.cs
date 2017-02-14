using System;
using System.Linq;

namespace CiaoApp.Web.Models.Promises.Actions
{
    public class RefuseAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            if ((_promise != null) && ((_promise.GetCurrentState().Status == TransactionStatus.RequestRevoked) || (_promise.GetCurrentState().Status == TransactionStatus.AcceptRevoked)))
            {
                return ActorRole.Executor;
            }
            else
            {
                return ActorRole.Initiator;
            }
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.RefuseAction;
        }

        public override bool IsActorEligible()
        {
            return ((CheckEligibility(TransactionStatus.StateRevoked, ActorRole.Initiator))
                || (CheckEligibility(TransactionStatus.PromiseRevoked, ActorRole.Initiator))
                || (CheckEligibility(TransactionStatus.AcceptRevoked, ActorRole.Executor))
                || (CheckEligibility(TransactionStatus.RequestRevoked, ActorRole.Executor)));
        }

        protected override void ActionLogic()
        {
            if (_promise.States.Count < 2)
            {
                throw new InvalidOperationException("Trying to REFUSE transaction which has too few states. Could not happen by application logic.");
            }
            NewState(_promise.States.Skip(_promise.States.Count - 2).First().Status);
        }
    }
}
