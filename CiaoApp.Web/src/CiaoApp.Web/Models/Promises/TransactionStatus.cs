namespace CiaoApp.Web.Models.Promises
{
    public enum TransactionStatus
    {
        NotReady,
        Requested,
        Promised,
        Stated,
        Accepted,
        Declined,
        Quit,
        Rejected,
        Stopped,
        RequestRevoked,
        PromiseRevoked,
        StateRevoked,
        AcceptRevoked
    }
}
