using System;
using System.Collections.Generic;
using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Messages;
using CiaoApp.Web.Services.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CiaoApp.Web.Data.DataAccess
{
    public class MessageAccess : IMessageAccess
    {

        private readonly ApplicationDbContext _dbContext;

        public MessageAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddNewMessageToPromise(Actor author, int promiseId, MessageType type, string text)
        {
            var promise = _dbContext.Promise.Include(prm => prm.Executor).Include(prm => prm.Initiator).FirstOrDefault(prm => prm.Id == promiseId);
            if (promise == null)
            {
                return false;
            }
            if (promise.Initiator.Id != author.Id && promise.Executor.Id != author.Id)
            {
                return false;
            }
            var message = new Message { Author = author, AuthorId = author.Id, CreatedOn = DateTime.Now, Promise = promise, PromiseId = promise.Id, Text = text, Type = type };
            _dbContext.Message.Add(message);
            _dbContext.SaveChanges();
            return true;            
        }

        public IList<Message> GetAllMessagesForPromise(int promiseId)
        {
            return _dbContext.Message.Where(msg => msg.PromiseId == promiseId).ToList();
        }
    }
}
