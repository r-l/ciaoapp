using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Contacts;
using System.Collections.Generic;

namespace CiaoApp.Web.Services.Persistence
{
    public interface IContactAccess
    {
        IList<Actor> GetUserContacts(int userId);
        IList<Actor> GetUserContacts(int userId, string prefix);
        Contact CreateNewContact(int userId, int contactId, string nickname);
        ContactGroup CreateNewContactGroup(int userId, string name);
        ContactGroup GetDefaultContactGroup(int userId);
        IList<ContactGroup> GetUserContactGroups(int userId);
    }
}
