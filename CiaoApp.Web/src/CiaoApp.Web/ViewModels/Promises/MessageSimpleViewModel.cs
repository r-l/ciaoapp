using System;

namespace CiaoApp.Web.ViewModels.Promises
{
    public class MessageSimpleViewModel
    {
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AuthorName { get; set; }
        public bool IsAuthorCurrentUser { get; set; }
    }
}
