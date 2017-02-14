namespace CiaoApp.Web.Models.Promises.Actions
{
    public class RejectAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Initiator;
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.RejectAction;
        }

        public override bool IsActorEligible()
        {
            return CheckEligibility(TransactionStatus.Stated, ActorRole.Initiator);
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.Rejected);
        }
    }
}
