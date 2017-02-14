using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.Models.Promises.Associations;

namespace CiaoApp.Web.Services.Persistence
{
    public interface IAssociationAccess
    {
        bool AddAssociation(int parentId, int childId, AssociationType type, TransactionStatus? targetState);
    }
}
