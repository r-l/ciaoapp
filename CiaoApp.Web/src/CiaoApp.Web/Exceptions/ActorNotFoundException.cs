using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiaoApp.Web.Exceptions
{           
        public class ActorNotFoundException : System.Exception
        {
            public ActorNotFoundException() : base() { }
            public ActorNotFoundException(string message) : base(message) { }
            public ActorNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        
        }
    
}
