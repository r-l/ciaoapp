using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Contacts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CiaoApp.Web.Models.Promises
{
    public class Offer : BasePromise
    {
        public Offer() : base() { }

        public Actor Offerer { get; set; }
        public OfferTargetType TargetType { get; set; }
        public int? SelectedContactGroupId { get; set; }
        public virtual ContactGroup SelectedContactGroup { get; set; }
    }
}
