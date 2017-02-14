using System.ComponentModel.DataAnnotations;

namespace CiaoApp.Web.ViewModels.Contacts
{
    public class NewContactGroupViewModel
    {
        [Required]
        [Display(Name = "What is the name of the new Group?")]
        public string name { get; set; }
    }
}
