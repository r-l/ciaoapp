using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.Models.Promises.Associations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CiaoApp.Web.ViewModels.Associations
{
    public class NewAssociationViewModel
    {
        [HiddenInput]
        public int CreatingPromiseId { get; set; }
        [HiddenInput]
        public int TargetPromiseId { get; set; }
        public AssociationType Type { get; set; }
        public TransactionStatus? TargetState { get; set; }
        public AssociationContext Context { get; set; }

        public IEnumerable<SelectListItem> AssociationTypes = Enum.GetValues(typeof(AssociationType)).Cast<AssociationType>().Select(assoc => new SelectListItem { Text = assoc.ToString(), Value = assoc.ToString(), Selected = false });
    }
}
