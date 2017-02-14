using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.Models.Promises.Associations;
using CiaoApp.Web.ViewModels.Promises;

namespace CiaoApp.Web.ViewModels.Associations
{
    public class AssociationViewModel
    {
        public AssociationKind Kind { get; set; }
        public BasePromise TargetPromise { get; set; }
        public AssociationType Type { get; set; }
        public TransactionStatus? TargetState {get; set; }        
    }
}
