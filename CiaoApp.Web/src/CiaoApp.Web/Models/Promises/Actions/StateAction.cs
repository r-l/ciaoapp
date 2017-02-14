namespace CiaoApp.Web.Models.Promises.Actions
{
    public class StateAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Executor;
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.StateAction;
        }

        public override bool IsActorEligible()
        {
            return CheckEligibility(TransactionStatus.Promised, ActorRole.Executor);
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.Stated);
        }
    }
}
