using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CiaoApp.Web.ViewModels.Contacts
{
    public class ContactViewModel : IValidatableObject
    {
        [Required]
        [Display(Name = "This contact should be called")]
        public string Nickname { get; set; }

        [HiddenInput]
        public string ActorId { get; set; }

        [Display(Name = "Search for existing person")]
        public string ActorName { get; set; }

        [Display(Name = "This contact is virtual and I will manage its Promises")]
        public bool IsVirtual { get; set; }

        public ContactViewModel()
        {
            IsVirtual = false;
            ActorId = "-1";
        }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (IsVirtual == false && int.Parse(ActorId) < 1)
            {
                yield return new ValidationResult(
                    "You have to select an existing user for non-virtual contacts.",
                    new[] { "ActorName" });
            }

        }
    }
}
