using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Messages;
using System.Collections.Generic;

namespace CiaoApp.Web.Services.Persistence
{
    public interface IMessageAccess
    {
        bool AddNewMessageToPromise(Actor author, int promiseId, MessageType type, string text);
        IList<Message> GetAllMessagesForPromise(int promiseId);
    }
}
