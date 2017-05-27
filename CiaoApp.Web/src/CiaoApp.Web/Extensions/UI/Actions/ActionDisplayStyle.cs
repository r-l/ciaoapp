using CiaoApp.Web.Models.Promises.Actions;

namespace CiaoApp.Web.Extensions.UI.Actions
{
    public static class ActionDisplayStyle
    {
        public static DisplayStyle GetDisplayStyle(this TransactionActionBase transactionAction)
        {
            switch (transactionAction.GetActionType())
            {
                case "AcceptAction":
                    return new DisplayStyle { Class = "btn-success", Icon = "glyphicon-thumbs-up" };
                case "AllowAction":
                    return new DisplayStyle { Class = "btn-success", Icon = "glyphicon-check" };
                case "DeclineAction":
                    return new DisplayStyle { Class = "btn-danger", Icon = "glyphicon-remove" };
                case "PromiseAction":
                    return new DisplayStyle { Class = "btn-success", Icon = "glyphicon-flag" };
                case "QuitAction":
                    return new DisplayStyle { Class = "btn-danger", Icon = "glyphicon-trash" };
                case "RefuseAction":
                    return new DisplayStyle { Class = "btn-danger", Icon = "glyphicon-ban-circle" };
                case "RejectAction":
                    return new DisplayStyle { Class = "btn-danger", Icon = "glyphicon-thumbs-down" };
                case "RequestAction":
                    return new DisplayStyle { Class = "btn-success", Icon = "glyphicon-envelope" };
                case "RevokeAcceptAction":                    
                case "RevokePromiseAction":                    
                case "RevokeRequestAction":                    
                case "RevokeStateAction":
                    return new DisplayStyle { Class = "btn-warning", Icon = "glyphicon-remove-circle" };
                case "StateAction":
                    return new DisplayStyle { Class = "btn-success", Icon = "glyphicon-ok-sign" };
                case "StopAction":
                    return new DisplayStyle { Class = "btn-danger", Icon = "glyphicon-remove-sign" };
                default:
                    return new DisplayStyle { Class = "btn-info", Icon = "glyphicon-info-sign" };
            }
        }
    }
}
