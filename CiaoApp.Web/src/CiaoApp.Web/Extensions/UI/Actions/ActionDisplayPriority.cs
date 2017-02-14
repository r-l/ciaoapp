using CiaoApp.Web.Models.Promises.Actions;

namespace CiaoApp.Web.Extensions.UI.Actions
{
    public static class ActionDisplayPriority
    {
        public static int GetDisplayPriority(this TransactionActionBase transactionAction)
        {
            switch (transactionAction.GetActionType())
            {
                case "AcceptAction":
                    return 85;
                case "AllowAction":
                    return 60;
                case "DeclineAction":
                    return 80;
                case "PromiseAction":
                    return 95;
                case "QuitAction":
                    return 70;
                case "RefuseAction":
                    return 55;
                case "RejectAction":
                    return 75;
                case "RequestAction":
                    return 100;
                case "RevokeAcceptAction":
                    return 50;
                case "RevokePromiseAction":
                    return 40;
                case "RevokeRequestAction":
                    return 35;
                case "RevokeStateAction":
                    return 45;
                case "StateAction":
                    return 90;
                case "StopAction":
                    return 65;
                default:
                    return 0;
            }
        }
    }
}
