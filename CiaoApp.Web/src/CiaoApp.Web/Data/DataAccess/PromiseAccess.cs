using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CiaoApp.Web.Data.DataAccess
{
    public class PromiseAccess : IPromiseAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public PromiseAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Promise> GetAllActorPromises(Actor actor)
        {
            return _dbContext.Promise.Where(prm => (prm.Executor.Id == actor.Id) || (prm.Initiator.Id == actor.Id)).Include(prm => prm.Initiator).Include(prm => prm.Executor).Include(prm => prm.States).ToList();
        }

        public IList<Promise> GetAllActorPromises(Actor actor, ActorRole role)
        {
            return (role == ActorRole.Executor) ? _dbContext.Promise.Where(prm => prm.Executor.Id == actor.Id).ToList() : _dbContext.Promise.Where(prm => prm.Initiator.Id == actor.Id).Include(prm => prm.States).ToList();
        }

        public Promise LoadPromiseById(int id)
        {
            return _dbContext.Promise.Where(prm => prm.Id == id).Include(prm => prm.Initiator).Include(prm => prm.Executor).Include(prm => prm.States).Include(prm => prm.ParentAssociations).ThenInclude(asoc => asoc.Parent).Include(prm => prm.ChildAssociations).ThenInclude(asoc => asoc.Child).FirstOrDefault();
        }

        public Promise SavePromise(Promise promise)
        {
            _dbContext.Entry(promise).State = promise.Id == 0 ? EntityState.Added : EntityState.Modified;
            foreach (var state in promise.States)
            {
                if (state.Id < 1)
                {
                    _dbContext.Entry(state).State = EntityState.Added;
                }
            }
            _dbContext.SaveChanges();
            return promise;
        }

        public IList<Promise> SearchAllActorPromises(Actor actor, string prefix)
        {
            var promises = _dbContext.Promise.Where(prm => (prm.Executor.Id == actor.Id) || (prm.Initiator.Id == actor.Id)).Include(prm => prm.Initiator).Include(prm => prm.Executor).Include(prm => prm.States);
            //return promises.Where(prm => ("Promise " + prm.Id + " " + prm.Product + " " + prm.Initiator.GetFullName(true, false) + " " + prm.Executor.GetFullName(true, false)).ToLower().Contains(prefix)).ToList();
            return promises.Where(prm => ("Promise " + prm.Id + " " + prm.Product).ToLower().Contains(prefix.ToLower())).ToList();
        }
    }
}
