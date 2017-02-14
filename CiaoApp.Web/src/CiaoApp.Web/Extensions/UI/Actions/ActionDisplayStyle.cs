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
                    return new DisplayStyle { ButtonClass = "btn-success", GlyphiconName = "glyphicon-thumbs-up" };
                case "AllowAction":
                    return new DisplayStyle { ButtonClass = "btn-success", GlyphiconName = "glyphicon-check" };
                case "DeclineAction":
                    return new DisplayStyle { ButtonClass = "btn-danger", GlyphiconName = "glyphicon-remove" };
                case "PromiseAction":
                    return new DisplayStyle { ButtonClass = "btn-success", GlyphiconName = "glyphicon-flag" };
                case "QuitAction":
                    return new DisplayStyle { ButtonClass = "btn-danger", GlyphiconName = "glyphicon-trash" };
                case "RefuseAction":
                    return new DisplayStyle { ButtonClass = "btn-danger", GlyphiconName = "glyphicon-ban-circle" };
                case "RejectAction":
                    return new DisplayStyle { ButtonClass = "btn-danger", GlyphiconName = "glyphicon-thumbs-down" };
                case "RequestAction":
                    return new DisplayStyle { ButtonClass = "btn-success", GlyphiconName = "glyphicon-envelope" };
                case "RevokeAcceptAction":
                    return new DisplayStyle { ButtonClass = "btn-warning", GlyphiconName = "glyphicon-remove-circle" };
                case "RevokePromiseAction":
                    return new DisplayStyle { ButtonClass = "btn-warning", GlyphiconName = "glyphicon-remove-circle" };
                case "RevokeRequestAction":
                    return new DisplayStyle { ButtonClass = "btn-warning", GlyphiconName = "glyphicon-remove-circle" };
                case "RevokeStateAction":
                    return new DisplayStyle { ButtonClass = "btn-warning", GlyphiconName = "glyphicon-remove-circle" };
                case "StateAction":
                    return new DisplayStyle { ButtonClass = "btn-success", GlyphiconName = "glyphicon-ok-sign" };
                case "StopAction":
                    return new DisplayStyle { ButtonClass = "btn-danger", GlyphiconName = "glyphicon-remove-sign" };
                default:
                    return new DisplayStyle { ButtonClass = "btn-info", GlyphiconName = "glyphicon-info-sign" };
            }
        }
    }
}
