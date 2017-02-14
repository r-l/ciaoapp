using CiaoApp.Web.Extensions.Common;
using CiaoApp.Web.Models.Promises;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CiaoApp.Web.ViewModels.Offers
{
    public class NewOfferViewModel : IValidatableObject
    {

        public NewOfferViewModel()
        {
            TargetContactGroupId = -1;
        }

        [Required]
        [Display(Name = "Whom do you offer to?")]
        public OfferTargetType TargetType { get; set; }

        [HiddenInput]
        public int? TargetContactGroupId { get; set; }

        [Display(Name = "Choose the target contact group")]
        public string TargetContactGroupName { get; set; }

        [Required]
        [Display(Name = "What do you offer?")]
        public string Product { get; set; }

        public IEnumerable<SelectListItem> TargetTypes = Enum.GetValues(typeof(OfferTargetType)).Cast<OfferTargetType>().Select(targetType => new SelectListItem { Text = targetType.GetDescription(), Value = targetType.ToString(), Selected = false });

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (TargetType == OfferTargetType.SelectedContactGroup && TargetContactGroupId < 1)
            {
                yield return new ValidationResult(
                    "You have to select an existing contact group.",
                    new[] { "TargetType" });
            }

        }
    }
}
