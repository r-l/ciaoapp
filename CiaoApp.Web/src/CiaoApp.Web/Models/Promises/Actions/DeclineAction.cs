namespace CiaoApp.Web.Models.Promises.Actions
{
    public class DeclineAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Executor;
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.DeclineAction;
        }

        public override bool IsActorEligible()
        {
            return CheckEligibility(TransactionStatus.Requested, ActorRole.Executor);
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.Declined);
        }
    }
}
