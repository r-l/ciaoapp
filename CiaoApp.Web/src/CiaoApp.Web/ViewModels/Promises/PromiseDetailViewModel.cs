using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.ViewModels.Associations;
using System;
using System.Collections.Generic;

namespace CiaoApp.Web.ViewModels.Promises
{
    public class PromiseDetailViewModel
    {
        public int Id { get; set; }
        public TransactionStatus CurrentStatus { get; set; }

        public string InitiatorName { get; set; }
        public string ExecutorName { get; set; }

        public string Product { get; set; }
        public TermType TermType { get; set; }
        public DateTime? Term { get; set; }

        public List<ActionViewModel> InitiatorActions { get; set; }
        public List<ActionViewModel> ExecutorActions { get; set; }

        public List<MessageSimpleViewModel> Messages { get; set; }

        public AllAssociationsViewModel AllAssociations { get; set; }
    }
}
