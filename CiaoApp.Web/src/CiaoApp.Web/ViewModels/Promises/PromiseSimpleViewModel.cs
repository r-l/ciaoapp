using CiaoApp.Web.Models.Promises;
using System;

namespace CiaoApp.Web.ViewModels.Promises
{
    public class PromiseSimpleViewModel
    {
        public int Id { get; set; }
        public TransactionStatus CurrentStatus { get; set; }

        public string InitiatorName { get; set; }
        public string ExecutorName { get; set; }

        public string Product { get; set; }
        public TermType TermType { get; set; }
        public DateTime? Term { get; set; }

        public string GetShortProduct(int numberOfCharacters, bool withElipsis = true)
        {
            return Product.Length <= numberOfCharacters ? Product : Product.Substring(0, numberOfCharacters) + (withElipsis ? "..." : "");
        }
    }
}
