using CiaoApp.Web.Services.Persistence;
using System.Collections.Generic;
using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Promises;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace CiaoApp.Web.Data.DataAccess
{
    public class OfferAccess : IOfferAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public OfferAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Offer> GetAllOffers(Actor offerer)
        {
            return _dbContext.Offer.Where(offer => (offer.Offerer.Id == offerer.Id)).Include(offer => offer.Offerer).ToList();
        }

        public IList<Offer> GetAllOffersForActor(Actor offerer, Actor target)
        {
            return _dbContext.Offer.Where(offer => (offer.Offerer.Id == offerer.Id) && ((offer.TargetType == OfferTargetType.Public) || (offer.SelectedContactGroup.Contacts.Where(contact => contact.ActorId == target.Id).Count()>0))).Include(offer => offer.Offerer).ToList();
        }

        public bool IsOfferedToActor(Offer offer, Actor target)
        {
            if (offer.TargetType == OfferTargetType.Public)
            {
                return true;
            }
            if (_dbContext.Offer.Where(off => (offer.Id == off.Id) && (off.SelectedContactGroup.Contacts.Where(contact => contact.ActorId == target.Id).Count() > 0)).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public Offer LoadOfferById(int id)
        {
            return _dbContext.Offer.Where(offer => (offer.Id == id)).Include(offer => offer.Offerer).FirstOrDefault();
        }

        public Offer SaveOffer(Offer offer)
        {
            _dbContext.Entry(offer).State = offer.Id == 0 ? EntityState.Added : EntityState.Modified;            
            _dbContext.SaveChanges();
            return offer;
        }
    }
}
