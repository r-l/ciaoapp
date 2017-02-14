using System.Collections.Generic;

namespace CiaoApp.Web.ViewModels.Associations
{
    public class AllAssociationsViewModel
    {
        public IList<AssociationViewModel> AllAssociations { get; set; }
        public NewAssociationViewModel NewAssociation { get; set; }
    }
}
