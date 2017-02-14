using CiaoApp.Web.ViewModels.Associations;

namespace CiaoApp.Web.ViewModels.Offers
{
    public class OfferViewModel : NewOfferViewModel
    {
        public int Id { get; set; }
        public AllAssociationsViewModel AllAssociations { get; set; }            
    }
}
