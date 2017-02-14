using System.Linq;

namespace CiaoApp.Web.Models.Promises.Associations
{
    public class Association : BaseEntity
    {
        public BasePromise Parent { get; set; }
        public BasePromise Child { get; set; }
        public AssociationType Type { get; set; }
        public TransactionStatus? TargetState { get; set; }

        public bool IsValid()
        {
            if (Parent == null || Child == null || Parent.Id == Child.Id)
            {
                return false;
            }
            if (AssociationAlreadyExists())
            {
                return false;
            }
            switch (Type)
            {
                case AssociationType.IsBlockedBy:
                    if (!HasExpectedPromiseType<Promise>() || TargetState == null)
                    {
                        return false;
                    }
                    break;
                case AssociationType.IsNotifiedWhen:
                    if (!HasExpectedPromiseType<Promise>() || TargetState == null)
                    {
                        return false;
                    }
                    break;
                case AssociationType.IsCreatedWhen:
                    if (!HasExpectedPromiseType<Offer>() || TargetState == null)
                    {
                        return false;
                    }
                    break;
                case AssociationType.IsOriginOf:
                    if (!HasExpectedPromiseType<Offer,Promise>())
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        private bool HasExpectedPromiseType<T>()
        {
            return (Parent.GetType() == typeof(T) && Child.GetType() == typeof(T));
        }
        private bool HasExpectedPromiseType<TParent,TChild>()
        {
            return (Parent.GetType() == typeof(TParent) && Child.GetType() == typeof(TChild));
        }

        private bool AssociationAlreadyExists()
        {
            return !(Parent.ChildAssociations.FirstOrDefault(assoc => ((assoc.Child.Id == Child.Id) && (assoc.Type == Type) && (assoc.TargetState == TargetState))) == null);
        }
    }
}