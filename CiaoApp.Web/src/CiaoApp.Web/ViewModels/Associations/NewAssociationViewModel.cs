using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.Models.Promises.Associations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CiaoApp.Web.Extensions.Common;

namespace CiaoApp.Web.ViewModels.Associations
{
    public class NewAssociationViewModel
    {
        public NewAssociationViewModel(AssociationContext context)
        {
            Context = context;
            AssociationTypes = Enum.GetValues(typeof(AssociationType)).Cast<AssociationType>().Where(assoc => context == AssociationContext.Offer ? (assoc.GetClass() == AssociationTypeClass.Offer || assoc.GetClass() == AssociationTypeClass.Common) : (assoc.GetClass() == AssociationTypeClass.Promise || assoc.GetClass() == AssociationTypeClass.Common)).Select(assoc => new SelectListItem { Text = assoc.GetDisplayName(), Value = assoc.ToString(), Selected = false });
            TargetStates = Enum.GetValues(typeof(TransactionStatus)).Cast<TransactionStatus>().Select(status => new SelectListItem { Text = status.GetDisplayName(), Value = status.ToString(), Selected = false });
        }

        public NewAssociationViewModel() { }
        

        public IEnumerable<SelectListItem> AssociationTypes { get; set; }
        public IEnumerable<SelectListItem> TargetStates { get; set; }

        [HiddenInput]
        public int CreatingPromiseId { get; set; }
        [HiddenInput]
        [Display(Name = "... the following commitment...")]
        public int TargetPromiseId { get; set; }
        [Display(Name = "This commitment")]
        public AssociationType Type { get; set; }
        [Display(Name = "... reaches this state")]
        public TransactionStatus? TargetState { get; set; }
        public AssociationContext Context { get; set; }

        
    }
}
