using System.Runtime.Serialization;

namespace dbTask
{
    [DataContract]
    public class Good: IEntity
    {
        [DataMember]
        public long Id { get; private set;}
        
        [DataMember]
        public string Name { get; private set;}
        
        [DataMember]
        public string Description { get; private set;}
        
        [DataMember]
        public long ShopId { get; private set;}
        
        [DataMember]
        public string Category { get; private set; }

        public Good(long id, string name, long shopId, string description, string category)
        {
            Id = id;
            Name = name;
            ShopId = shopId;
            Description = description;
            Category = category;
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