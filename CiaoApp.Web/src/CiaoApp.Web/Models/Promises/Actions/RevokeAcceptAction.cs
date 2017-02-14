namespace CiaoApp.Web.Models.Promises.Actions
{
    public class RevokeAcceptAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Initiator;
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.RevokeAcceptAction;        }

        public override bool IsActorEligible()
        {
            return CheckEligibility(TransactionStatus.Accepted, ActorRole.Initiator);
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.AcceptRevoked);
        }
    }
}
