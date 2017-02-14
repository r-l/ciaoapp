using CiaoApp.Web.Models.Promises.Actions;
using CiaoApp.Web.ViewModels.Promises;
using CiaoApp.Web.Extensions.UI.Actions;

namespace CiaoApp.Web.Mappers
{
    public static class ActionMappper
    {
        public static ActionViewModel MapToActionView (this TransactionActionBase transactionAction)
        {
            var DisplayStyle = transactionAction.GetDisplayStyle();
            return new ActionViewModel
            {
                Label = transactionAction.GetActionName(),
                Type = transactionAction.GetActionType(),
                ButtonClass = DisplayStyle.ButtonClass,
                GlyphiconName = DisplayStyle.GlyphiconName,
                DisplayPriority = transactionAction.GetDisplayPriority()                    
            };
        }
    }
}
