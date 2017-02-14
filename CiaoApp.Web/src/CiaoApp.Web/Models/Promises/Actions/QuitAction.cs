namespace CiaoApp.Web.Models.Promises.Actions
{
    public class QuitAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Initiator;
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.QuitAction;
        }

        public override bool IsActorEligible()
        {
            return CheckEligibility(TransactionStatus.Declined, ActorRole.Initiator);
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.Quit);
        }
    }
}
