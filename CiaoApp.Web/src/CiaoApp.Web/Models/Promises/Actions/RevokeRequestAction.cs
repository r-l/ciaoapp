﻿namespace CiaoApp.Web.Models.Promises.Actions
{
    public class RevokeRequestAction : TransactionActionBase
    {
        public override ActorRole GetActionActorRole()
        {
            return ActorRole.Initiator;
        }

        public override string GetActionName()
        {
            return Resources.Texts.Actions.RevokeRequestAction;
        }

        public override bool IsActorEligible()
        {
            return ((CheckEligibility(TransactionStatus.Requested, ActorRole.Initiator))
                || (CheckEligibility(TransactionStatus.Stated, ActorRole.Initiator))
                || (CheckEligibility(TransactionStatus.Promised, ActorRole.Initiator))
                || (CheckEligibility(TransactionStatus.Accepted, ActorRole.Initiator)));
        }

        protected override void ActionLogic()
        {
            NewState(TransactionStatus.RequestRevoked);
        }
    }
}
