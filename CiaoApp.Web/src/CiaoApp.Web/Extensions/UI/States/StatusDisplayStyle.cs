using CiaoApp.Web.Models.Promises;

namespace CiaoApp.Web.Extensions.UI.States
{
    public static class StatusDisplayStyle
    {
        public static DisplayStyle GetDisplayStyle(this TransactionStatus transactionStatus)
        {
            switch (transactionStatus)
            {
                // Terminal states
                case TransactionStatus.Accepted:
                    return new DisplayStyle { Class = "label-success" };
                case TransactionStatus.Stopped:
                case TransactionStatus.Quit:
                    return new DisplayStyle { Class = "label-danger" };

                //Common states
                
                case TransactionStatus.Requested:
                case TransactionStatus.Promised:
                case TransactionStatus.Stated:
                    return new DisplayStyle { Class = "label-info" };
                case TransactionStatus.NotReady:
                case TransactionStatus.Declined:              
                case TransactionStatus.Rejected:
                    return new DisplayStyle { Class = "label-warning" };

                // Revoke states
                case TransactionStatus.RequestRevoked:
                case TransactionStatus.PromiseRevoked:
                case TransactionStatus.StateRevoked:
                case TransactionStatus.AcceptRevoked:
                    return new DisplayStyle { Class = "label-warning" };
                default:
                    return new DisplayStyle();
            }

        }
    }
}