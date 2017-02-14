namespace CiaoApp.Web.Models.Promises.Actions
{
    public class RevokeStateAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Executor;
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.RevokeStateAction;
        }

        public override bool IsActorEligible()
        {
            return ((CheckEligibility(TransactionStatus.Accepted, ActorRole.Executor))
                || (CheckEligibility(TransactionStatus.Stated, ActorRole.Executor)));
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.StateRevoked);
        }
    }
}
