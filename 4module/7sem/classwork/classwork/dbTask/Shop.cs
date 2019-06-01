using System;
using System.Runtime.Serialization;

namespace dbTask
{
    [DataContract]
    public class Shop: IEntity
    {
        [DataMember]
        public long Id { get; private set;}
        
        [DataMember]
        public string Name { get; private set;}
        
        [DataMember]
        public string City { get; private set;}
        
        [DataMember]
        public string Country { get; private set;}
        
        [DataMember]
        public string TelephoneNumber { get; private set;}

        public Shop(long id, string name, string city, string country, string phoneNumber)
        {
            Id = id;
            Name = name;
            City = city;
            Country = country;
            TelephoneNumber = phoneNumber;
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
            return this.Equals(obj as Shop);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}