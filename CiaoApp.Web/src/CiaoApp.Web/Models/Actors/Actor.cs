using CiaoApp.Web.Models.Contacts;
using CiaoApp.Web.Models.Promises;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CiaoApp.Web.Models.Actors
{
    public class Actor : BaseEntity
    {
        public Actor()
        {
            this.Promises = new HashSet<Promise>();
            this.Requests = new HashSet<Promise>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsVirtual { get; set; }

        public string Email { get; set; }

        [InverseProperty("Initiator")]
        public virtual ICollection<Promise> Promises { get; set; }

        [InverseProperty("Executor")]
        public virtual ICollection<Promise> Requests { get; set; }        

        public virtual ICollection<ContactGroup> ContactGroups { get; set; }

        public string GetFullName(bool withEmail = false, bool inverse = false)
        {
            string name;
            if (inverse)
            {
                name = LastName + ", " + FirstName;
            }
            else
            {
                name = FirstName + " " + LastName;
            }
            if (withEmail)
            {
                name += " (" + Email + ")";
            }
            return name;
        }

    }
}
