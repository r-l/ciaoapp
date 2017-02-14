using CiaoApp.Web.Models.Promises.Associations;
using CiaoApp.Web.ViewModels.Associations;

namespace CiaoApp.Web.Mappers
{
    public static class AssociationMapper
    {
        public static AssociationViewModel MapToAssociationView(this Association association, AssociationKind kind)
        {
            return new AssociationViewModel
            {
                Kind = kind,
                TargetState = association.TargetState,
                Type = association.Type,
                TargetPromise = kind == AssociationKind.Parent ? association.Parent : association.Child
            };
        }
    }
}
