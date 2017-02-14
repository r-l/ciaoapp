using CiaoApp.Web.Models.Contacts;
using CiaoApp.Web.ViewModels.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace CiaoApp.Web.Mappers
{
    public static class ContactGroupMapper
    {
        public static ContactGroupViewModel MapToView(this ContactGroup contactGroup)
        {
            var contacts = contactGroup.Contacts.Select(contact => contact.MapToBasicView()).OrderBy(cont => cont.Nickname).ToList();
            var viewModel = new ContactGroupViewModel
            {
                Id = contactGroup.Id,
                Name = contactGroup.Name,
                Contacts = new List<ContactSimpleViewModel>(contacts)
            };
            return viewModel;
        }
    }
}
