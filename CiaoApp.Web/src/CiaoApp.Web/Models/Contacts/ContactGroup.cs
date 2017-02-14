using System.Collections.Generic;

namespace CiaoApp.Web.Models.Contacts
{
    public class ContactGroup : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public bool IsDefault { get; set; }
    }
}
