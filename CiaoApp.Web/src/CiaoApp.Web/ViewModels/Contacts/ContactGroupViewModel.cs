using System.Collections.Generic;

namespace CiaoApp.Web.ViewModels.Contacts
{
    public class ContactGroupViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public IList<ContactSimpleViewModel> Contacts { get; set; }
    }
}
