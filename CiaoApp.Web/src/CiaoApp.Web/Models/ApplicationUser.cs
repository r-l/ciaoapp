using CiaoApp.Web.Models.Actors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CiaoApp.Web.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
