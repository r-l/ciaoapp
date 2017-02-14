using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Promises;
using System;

namespace CiaoApp.Web.Models.Notifications
{
    public class Notification : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? SeenOn { get; set; }
        public bool IsSeen { get; set; }
        public string Text { get; set; }
        public int OwnerId { get; set; }
        public virtual Actor Owner { get; set; }
        public int? RelatedPromiseId { get; set; }
        public virtual Promise RelatedPromise { get; set; }
        public NotificationType Type { get; set; }
    }
}
