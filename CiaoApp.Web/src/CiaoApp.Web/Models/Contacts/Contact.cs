using CiaoApp.Web.Models.Actors;

namespace CiaoApp.Web.Models.Contacts
{
    public class Contact : BaseEntity
    {
        public string Nickname { get; set; }

        public int ActorId { get; set; }

        virtual public Actor Actor { get; set; }        
    }
}
