using System.Runtime.Serialization;

namespace dbTask
{
    [DataContract]
    public class Customer:IEntity
    {
        [DataMember]
        public long Id { get; private set;}
        
        [DataMember]
        public string Name { get; private set;}
        
        [DataMember]
        public string LastName { get; private set;}
        
        [DataMember]
        public string Address { get; private set;}
        
        [DataMember]
        public string District { get; private set;}
        
        [DataMember]
        public string Country { get; private set;}
        
        [DataMember]
        public string PostalIndex { get; private set;}

        

        public Customer(long id, string name, string lastName, string address, string district, string country,
            string postalIndex)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Address = address;
            this.District = district;
            this.Country = country;
            this.PostalIndex = postalIndex;
        }
        
        public bool Equals(IEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return other.Id == Id;
        }
    }
}