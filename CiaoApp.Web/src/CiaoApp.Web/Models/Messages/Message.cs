using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Promises;
using System;

namespace CiaoApp.Web.Models.Messages
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public MessageType Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public int AuthorId { get; set; }
        public virtual Actor Author { get; set; }
        public int? PromiseId { get; set; }
        public virtual Promise Promise { get; set; }
    }
}
