using CiaoApp.Web.Models;
using System;

namespace CiaoApp.Web.Models.Promises
{
    public class PromiseState : BaseEntity
    {
        public TransactionStatus Status { get; set; }
        public DateTime Attained { get; set; }

        public int PromiseID { get; set; }
        public virtual Promise Promise { get; set; }
    }
}
