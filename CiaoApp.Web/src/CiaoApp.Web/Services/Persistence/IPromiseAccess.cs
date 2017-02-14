using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.Models.Actors;
using System.Collections.Generic;

namespace CiaoApp.Web.Services.Persistence
{
    public interface IPromiseAccess
    {
        IList<Promise> GetAllActorPromises(Actor actor);
        IList<Promise> GetAllActorPromises(Actor actor, ActorRole role);
        IList<Promise> SearchAllActorPromises(Actor actor, string prefix);
        Promise SavePromise(Promise promise);
        Promise LoadPromiseById(int id);
    }
}
