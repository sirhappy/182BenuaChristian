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
        public string Category { get; private set; }

        public Good(long id, string name, string description, string category)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
        }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Descr:{Description}, Category:{Category}";
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
            return this.Equals(obj as Good);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}