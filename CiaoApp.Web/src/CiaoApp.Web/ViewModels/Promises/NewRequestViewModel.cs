using CiaoApp.Web.Models.Promises;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CiaoApp.Web.ViewModels.Promises
{
    public class NewRequestViewModel
    {

        public NewRequestViewModel()
        {
            Term = DateTime.Today;
        }

        [Required]
        [Display(Name = "Who do you request from?")]
        public string Executor { get; set; }

        public int ExecutorId { get; set; }

        [HiddenInput]
        public int? OriginalOfferId { get; set; }

        [Required]
        [Display(Name = "What do you want?")]
        public string Product { get; set; }

        [Required]
        [Display(Name = "When would you like to have it?")]
        public TermType TermType { get; set; }

        [Display(Name = "Specify the date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Term { get; set; }

        public IEnumerable<SelectListItem> TermTypes = Enum.GetValues(typeof(TermType)).Cast<TermType>().Select(term => new SelectListItem { Text = term.ToString(), Value = term.ToString(), Selected = false });
    }
}
