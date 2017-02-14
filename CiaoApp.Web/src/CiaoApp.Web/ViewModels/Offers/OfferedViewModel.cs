using System.Collections.Generic;

namespace CiaoApp.Web.ViewModels.Offers
{
    public class OfferedViewModel
    {
        public IList<OfferSimpleViewModel> Offers { get; set; }
        public string OffererName { get; set; }

    }
}
