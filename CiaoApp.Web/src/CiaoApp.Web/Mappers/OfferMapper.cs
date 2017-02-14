using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.ViewModels.Associations;
using CiaoApp.Web.ViewModels.Offers;
using System.Collections.Generic;
using System.Linq;

namespace CiaoApp.Web.Mappers
{
    public static class OfferMapper
    {
        public static OfferSimpleViewModel MapToSimpleOffer(this Offer offer)
        {
            return new OfferSimpleViewModel
            {
                Id = offer.Id,
                Product = offer.Product
            };
        }

        public static OfferViewModel MapToOfferView(this Offer offer)
        {
            var associations = new List<AssociationViewModel>();
            associations.AddRange(offer.ParentAssociations.Select(assoc => assoc.MapToAssociationView(AssociationKind.Parent)).Concat(offer.ChildAssociations.Select(assoc => assoc.MapToAssociationView(AssociationKind.Child))));

            return new OfferViewModel
            {
                Id = offer.Id,
                Product = offer.Product,
                TargetType = offer.TargetType,
                TargetContactGroupId = offer.SelectedContactGroupId,
                TargetContactGroupName = offer.SelectedContactGroup == null ? "" : offer.SelectedContactGroup.Name,
                AllAssociations = new AllAssociationsViewModel { AllAssociations = associations, NewAssociation = new NewAssociationViewModel { CreatingPromiseId = offer.Id, Context = AssociationContext.Offer } }
            };
        }
    }
}
