namespace CiaoApp.Web.Models.Promises.Actions
{
    public class RevokePromiseAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Executor;
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.RevokePromiseAction;
        }

        public override bool IsActorEligible()
        {
            return ((CheckEligibility(TransactionStatus.Stated, ActorRole.Executor))
                || (CheckEligibility(TransactionStatus.Promised, ActorRole.Executor))
                || (CheckEligibility(TransactionStatus.Accepted, ActorRole.Executor)));
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.PromiseRevoked);
        }
    }
}
