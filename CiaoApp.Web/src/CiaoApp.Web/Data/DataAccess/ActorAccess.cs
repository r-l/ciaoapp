using CiaoApp.Web.Exceptions;
using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CiaoApp.Web.Data.DataAccess
{
    public class ActorAccess : IActorAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public ActorAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Actor> GetActorByIdAsync(int Id)
        {
            var actor = await _dbContext.Actor.Where(act => act.Id == Id).FirstOrDefaultAsync();
            if (actor == null)
            {
                throw new ActorNotFoundException("No actor found for Id " + Id);
            }
            return actor;
        }

        public Actor SaveActor(Actor Actor)
        {
            _dbContext.Entry(Actor).State = Actor.Id < 1 ? EntityState.Added : EntityState.Modified;
            _dbContext.SaveChanges();
            return Actor;
        }
    }
}

