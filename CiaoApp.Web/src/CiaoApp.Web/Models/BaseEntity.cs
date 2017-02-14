using System.ComponentModel.DataAnnotations.Schema;

namespace CiaoApp.Web.Models
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
