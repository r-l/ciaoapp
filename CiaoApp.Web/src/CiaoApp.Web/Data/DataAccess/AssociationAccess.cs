using System;
using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.Services.Persistence;
using CiaoApp.Web.Models.Promises.Associations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CiaoApp.Web.Data.DataAccess
{
    public class AssociationAccess : IAssociationAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public AssociationAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddAssociation(int parentId, int childId, AssociationType type, TransactionStatus? targetState)
        {
            var parent = LoadOfferOrPromise(parentId);
            var child = LoadOfferOrPromise(childId);

            var association = new Association { Parent = parent, Child = child, Type = type, TargetState = targetState };
            if (association.IsValid())
            {
                _dbContext.Add(association);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        private BasePromise LoadOfferOrPromise(int id)
        {
            var offer = _dbContext.Offer.Include(bprm => bprm.ChildAssociations).ThenInclude(child => child.Child).Include(bprm => bprm.ParentAssociations).FirstOrDefault(bprm => bprm.Id == id);
            if (offer == null)
            {
                return _dbContext.Promise.Include(bprm => bprm.ChildAssociations).ThenInclude(child => child.Child).Include(bprm => bprm.ParentAssociations).FirstOrDefault(bprm => bprm.Id == id);
            }
            return offer;
        }
    }
}
