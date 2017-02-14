namespace CiaoApp.Web.Models.Promises.Actions
{
    public class RequestAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Initiator;
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.RequestAction;
        }

        public override bool IsActorEligible()
        {
            return CheckEligibility(TransactionStatus.NotReady, ActorRole.Initiator);
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.Requested);
        }
    }
}
