using System.Collections.Generic;
using System.Runtime.Serialization;

namespace dbTask
{
    [DataContract]
    public class Order: IEntity
    {
        [DataMember]
        public long Id { get; private set; }
        
        [DataMember]
        public long CustomerId { get; private set; }
        
        [DataMember]
        public long ShopId { get; private set; }
        
        [DataMember]
        public long GoodId { get; private set;}
        
        [DataMember]
        public int GoodAmount { get; private set;}
        
        [DataMember]
        public double GoodCost { get; private set;}

        public Order(long id, long customerId, long shopId, long goodId,
            int goodAmount, double goodCost)
        {
            Id = id;
            CustomerId = customerId;
            ShopId = shopId;
            GoodId = goodId;
            GoodAmount = goodAmount;
            GoodCost = goodCost;
        }


        public override string ToString()
        {
            return $"Id:{Id}, CustomerId:{CustomerId}, ShopId:{ShopId}, GoodId:{GoodId}, GoodAmount:{GoodAmount}, " +
                   $"GoodCost:{GoodCost:F3}";
        }

        public bool Equals(IEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Order);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}