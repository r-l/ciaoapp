using CiaoApp.Web.Models.Promises;

namespace CiaoApp.Web.Extensions.Common
{
    public static class TransactionStatusExtension
    {
        public static string GetDisplayName(this TransactionStatus transactionStatus)
        {
            switch (transactionStatus)
            {
                case TransactionStatus.NotReady: return Resources.Texts.States.NotReady;
                case TransactionStatus.Requested: return Resources.Texts.States.Requested;
                case TransactionStatus.Promised: return Resources.Texts.States.Promised;
                case TransactionStatus.Stated: return Resources.Texts.States.Stated;
                case TransactionStatus.Accepted: return Resources.Texts.States.Accepted;
                case TransactionStatus.Declined: return Resources.Texts.States.Declined;
                case TransactionStatus.Quit: return Resources.Texts.States.Quit;
                case TransactionStatus.Rejected: return Resources.Texts.States.Rejected;
                case TransactionStatus.Stopped: return Resources.Texts.States.Stopped;
                case TransactionStatus.RequestRevoked: return Resources.Texts.States.RequestRevoked;
                case TransactionStatus.PromiseRevoked: return Resources.Texts.States.PromiseRevoked;
                case TransactionStatus.StateRevoked: return Resources.Texts.States.StateRevoked;
                case TransactionStatus.AcceptRevoked: return Resources.Texts.States.AcceptRevoked;
                default:
                    return transactionStatus.ToString();
            }

        }

        public static bool IsTerminal(this TransactionStatus transactionStatus)
        {
            switch (transactionStatus)
            {
                case TransactionStatus.Accepted:
                case TransactionStatus.Quit:
                case TransactionStatus.Stopped:
                    return true;
                default:
                    return false;
            }

        }
    }
}
