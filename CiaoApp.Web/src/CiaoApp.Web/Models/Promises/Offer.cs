using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Contacts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CiaoApp.Web.Models.Promises
{
    public class Offer : BasePromise
    {
        public Offer() : base() { }

        public Actor Offerer { get; set; }
        public OfferTargetType TargetType { get; set; }
        public int? SelectedContactGroupId { get; set; }
        public virtual ContactGroup SelectedContactGroup { get; set; }

        public List<int> GetCreatedPromisesForState(TransactionStatus state)
        {
            return ParentAssociations.Where(assoc => assoc.Type == Associations.AssociationType.IsCreatedWhen && assoc.TargetState == state).Select(assoc => assoc.Parent.Id ).ToList();
        }
    }
}
