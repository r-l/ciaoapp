namespace CiaoApp.Web.Models.Promises.Actions
{
    public class StopAction : TransactionActionBase
    {
        public override bool IsActorEligible()
        {
            return CheckEligibility(TransactionStatus.Rejected, ActorRole.Executor);
        }

        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Executor;
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.Stopped);
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.StopAction;
        }
    }
}
