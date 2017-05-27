using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Promises;
using System.Collections.Generic;

namespace CiaoApp.Web.Services.Persistence
{
    public interface IOfferAccess
    {
        IList<Offer> GetAllOffers(Actor offerer);
        IList<Offer> GetAllOffersForActor(Actor offerer, Actor target);
        Offer SaveOffer(Offer offer);
        Offer LoadOfferById(int id);
        bool IsOfferedToActor(Offer offer, Actor actor, bool allowHidden);
        IList<Offer> SearchAllActorOffers(Actor actor, string prefix);
    }
}
