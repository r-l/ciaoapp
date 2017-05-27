using System.Collections.Generic;

namespace CiaoApp.Web.Models.Promises
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public bool IsForPromise { get; set; }
        public bool IsForOffer { get; set; }
        public bool IsCustom { get; set; }
        public int? ActorId { get; set; }
        public virtual ICollection<TagAssociation> AssociatedPromises { get; set; }
    }
}
