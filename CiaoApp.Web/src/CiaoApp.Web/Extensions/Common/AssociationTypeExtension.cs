using CiaoApp.Web.Models.Promises.Associations;

namespace CiaoApp.Web.Extensions.Common
{
    public static class AssociationTypeExtension
    {
        public static string GetDisplayName(this AssociationType associationType)
        {
            switch (associationType)
            {
                case AssociationType.IsBlockedBy:
                    return "is blocked until";
                case AssociationType.IsAssociatedWith:
                    return "is associated with";
                case AssociationType.IsNotifiedWhen:
                    return "is notified when";
                case AssociationType.IsCreatedWhen:
                    return "is created when";
                case AssociationType.IsOriginOf:
                    return "is an origin of";
                default:
                    return associationType.ToString();
            }
            
        }

        public static AssociationTypeClass GetClass(this AssociationType associationType)
        {
            switch (associationType)
            {
                case AssociationType.IsBlockedBy:
                    return AssociationTypeClass.Promise;
                case AssociationType.IsAssociatedWith:
                    return AssociationTypeClass.Common;
                case AssociationType.IsNotifiedWhen:
                    return AssociationTypeClass.Promise;
                case AssociationType.IsCreatedWhen:
                    return AssociationTypeClass.Offer;
                case AssociationType.IsOriginOf:
                    return AssociationTypeClass.Hidden;
                default:
                    return AssociationTypeClass.Common;
            }

        }
    }
}
