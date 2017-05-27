using CiaoApp.Web.Models.Promises.Actions;
using CiaoApp.Web.Models.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace CiaoApp.Web.Models.Promises
{   
    public class Promise : BasePromise
    {

        private ActionFactory _actionFactory;

        public Promise() : base()
        {                   
            States = new List<PromiseState>();
            _actionFactory = new ActionFactory();
        }

        public Actor Initiator { get; set; }
        public Actor Executor { get; set; }        

        public DateTime? Term { get; set; }
        public TermType TermType { get; set; }

        public virtual List<PromiseState> States { get; set; }             

        public IEnumerable<TransactionActionBase> GetAllowedActions(Actor actor)
        {            
            return _actionFactory.GetActionsForPromise(this, actor);
        }

        public PromiseState GetCurrentState()
        {
            return States.LastOrDefault();
        }

        public int? GetOriginId()
        {
            var origin = ParentAssociations.FirstOrDefault(assoc => assoc.Type == Associations.AssociationType.IsOriginOf);
            if (origin == null) {
                return null;
            } else {
                return origin.Parent.Id;
            } 
        }

    }
}
