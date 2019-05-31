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
        public IList<long> CustomerIds { get; private set; }
        
        [DataMember]
        public IList<long> ShopIds { get; private set; }
        
        [DataMember]
        public IList<long> GoodIds { get; private set;}
        
        [DataMember]
        public IList<int> GoodsAmounts { get; private set;}
        
        [DataMember]
        public IList<double> GoodsCosts { get; private set;}

        public Order(long id, IList<long> customerIds, IList<long> shopIds, IList<long> goodIds,
            IList<int> goodsAmounts, IList<double> goodsCosts)
        {
            Id = id;
            CustomerIds = customerIds;
            ShopIds = shopIds;
            GoodIds = goodIds;
            GoodsAmounts = goodsAmounts;
            GoodsCosts = goodsCosts;
        }


        public override string ToString()
        {
            return $"Id:{Id}";
        }

        public bool Equals(IEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }
        
    }
}