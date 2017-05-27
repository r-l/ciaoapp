using CiaoApp.Web.Services.Persistence;
using System.Collections.Generic;
using CiaoApp.Web.Models.Actors;
using System.Linq;
using CiaoApp.Web.Exceptions;
using Microsoft.EntityFrameworkCore;
using CiaoApp.Web.Models.Contacts;
using System;

namespace CiaoApp.Web.Data.DataAccess
{
    public class ContactAccess : IContactAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ContactGroup CreateNewContactGroup(int userId, string name)
        {
            var actor = _dbContext.Actor.Where(act => act.Id == userId).Include(act => act.ContactGroups).FirstOrDefault();
            if (actor == null)
            {
                throw new ActorNotFoundException("Creating new Contact: User with id " + userId + " not found.");
            }
            var contactGroup = new ContactGroup { Contacts = new HashSet<Contact>(), IsDefault = false, Name = name };
            actor.ContactGroups.Add(contactGroup);
            _dbContext.SaveChanges();
            return contactGroup;
        }

        public Contact CreateNewContact(int userId, int contactId, string nickname)
        {
            var actor = _dbContext.Actor.Where(act => act.Id == userId).Include(act => act.ContactGroups).ThenInclude(crc => crc.Contacts).FirstOrDefault();
            if (actor == null)
            {
                throw new ActorNotFoundException("Creating new Contact: User with id " + userId + " not found.");
            }
            var contactGroup = GetOrCreateDefaultContactGroup(actor);
            var newContact = new Contact { Nickname = nickname };
            if (contactId > 0)
            {
                var target = _dbContext.Actor.Where(act => act.Id == contactId).FirstOrDefault();
                if (target == null)
                {
                    throw new ActorNotFoundException("Creating new Contact: Target actor with id " + contactId + " not found.");
                }
                newContact.Actor = target;
                newContact.ActorId = target.Id;
            }
            contactGroup.Contacts.Add(newContact);
            _dbContext.SaveChanges();
            return newContact;
        }

        public IList<ContactGroup> GetUserContactGroups(int userId)
        {
            var actor = _dbContext.Actor.Where(act => act.Id == userId).Include(act => act.ContactGroups).ThenInclude(crc => crc.Contacts).ThenInclude(cont => cont.Actor).FirstOrDefault();
            if (actor.ContactGroups.ToArray().Length < 1)
            {
                GetOrCreateDefaultContactGroup(actor);
                _dbContext.SaveChanges();
            }
            return actor.ContactGroups.ToList();
        }

        public IList<Actor> GetUserContacts(int userId)
        {
            // UNDONE This is shit
            return _dbContext.Actor.Where(act => act.Id != userId).ToList();
        }

        public IList<Actor> GetUserContacts(int userId, string prefix)
        {
            // UNDONE This is shit
            return _dbContext.Actor.Where(act => act.Id != userId && (act.Email.Contains(prefix) || act.FirstName.Contains(prefix) || act.LastName.Contains(prefix))).ToList();
        }

        public ContactGroup GetDefaultContactGroup(int userId)
        {
            var actor = _dbContext.Actor.Where(act => act.Id == userId).Include(act => act.ContactGroups).ThenInclude(crc => crc.Contacts).ThenInclude(cont => cont.Actor).FirstOrDefault();
            return GetOrCreateDefaultContactGroup(actor);
        }

        private ContactGroup GetOrCreateDefaultContactGroup(Actor actor)
        {
            var contactGroup = actor.ContactGroups.Where(crc => crc.IsDefault).FirstOrDefault();
            if (contactGroup == null)
            {
                contactGroup = new ContactGroup { Contacts = new HashSet<Contact>(), IsDefault = true, Name = "All contacts" };
                actor.ContactGroups.Add(contactGroup);
            }
            return contactGroup;
        }

        public IList<Actor> GetAllPeople(int userId)
        {
            return _dbContext.Actor.Where(act => act.Id != userId).ToList();
        }

        public IList<Actor> GetAllPeople(int userId, string prefix)
        {
            return _dbContext.Actor.Where(act => act.Id != userId && (act.Email.Contains(prefix) || act.FirstName.Contains(prefix) || act.LastName.Contains(prefix))).ToList();
        }
    }
}
