using CiaoApp.Web.Models.Promises;

namespace CiaoApp.Web.Extensions.Common
{
    public static class OfferTargetTypeDescription
    {
        public static string GetDescription(this OfferTargetType offerTargetType)
        {
            switch (offerTargetType)
            {
                case OfferTargetType.AllContacts:
                    return "All of your contacts";
                case OfferTargetType.SelectedContactGroup:
                    return "Selected contact group only";
                case OfferTargetType.Hidden:
                    return "Hidden";
                case OfferTargetType.Public:
                    return "Public";
                default:
                    return offerTargetType.ToString();
            }
        }
    }
}
