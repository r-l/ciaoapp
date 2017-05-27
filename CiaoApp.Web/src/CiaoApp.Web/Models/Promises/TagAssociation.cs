using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CiaoApp.Web.Models.Promises
{
    public class TagAssociation
    {
        [ForeignKey("BasePromise")]
        public int BasePromiseId { get; set; }
        public BasePromise BasePromise { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
