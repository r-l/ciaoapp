using CiaoApp.Web.Models.Promises.Associations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CiaoApp.Web.Models.Promises
{
    public abstract class BasePromise : BaseEntity
    {
        public BasePromise()
        {
            ParentAssociations = new HashSet<Association>();
            ChildAssociations = new HashSet<Association>();
        }
        [InverseProperty("Child")]
        public virtual ICollection<Association> ParentAssociations { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Association> ChildAssociations { get; set; }
        public string Product { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
