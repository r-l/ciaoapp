using CiaoApp.Web.Models.Messages;
using CiaoApp.Web.ViewModels.Promises;

namespace CiaoApp.Web.Mappers
{
    public static class MessageMapper
    {
        public static MessageSimpleViewModel MapToSimpleMessage(this Message message, int currentActorId)
        {
            return new MessageSimpleViewModel
            {
                AuthorName = message.Author.GetFullName(),
                CreatedOn = message.CreatedOn,
                Text = message.Text,
                IsAuthorCurrentUser = message.AuthorId == currentActorId
            };
        }
    }
}
