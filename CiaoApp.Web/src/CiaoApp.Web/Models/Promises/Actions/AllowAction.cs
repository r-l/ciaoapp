namespace CiaoApp.Web.Models.Promises.Actions
{
    public class AllowAction : TransactionActionBase
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
            return Resources.Texts.Actions.AllowAction;
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
            switch (_promise.GetCurrentState().Status)
            {
                case TransactionStatus.StateRevoked:
                    NewState(TransactionStatus.Promised);
                    break;
                case TransactionStatus.PromiseRevoked:
                    NewState(TransactionStatus.Declined);
                    break;
                case TransactionStatus.AcceptRevoked:
                    NewState(TransactionStatus.Rejected);
                    break;
                case TransactionStatus.RequestRevoked:
                    NewState(TransactionStatus.NotReady);
                    break;
            }
        }
    }
}
