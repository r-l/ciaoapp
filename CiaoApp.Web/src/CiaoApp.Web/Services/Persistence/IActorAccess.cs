using CiaoApp.Web.Models.Actors;
using System.Threading.Tasks;

namespace CiaoApp.Web.Services.Persistence
{
    public interface IActorAccess
    {
        Actor SaveActor(Actor Actor);
        Task<Actor> GetActorByIdAsync(int Id);
    }
}
