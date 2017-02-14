using CiaoApp.Web.Models.Contacts;
using CiaoApp.Web.ViewModels.Contacts;

namespace CiaoApp.Web.Mappers
{
    public static class ContactMapper
    {
        public static ContactSimpleViewModel MapToBasicView(this Contact contact)
        {
            return new ContactSimpleViewModel
            {
                Id = contact.Id,
                Nickname = contact.Nickname,
                IsVirtual = contact.Actor.IsVirtual
            };
        }
    }
}
