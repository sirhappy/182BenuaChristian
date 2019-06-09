using System.Collections.Generic;
using System.Runtime.Serialization;

namespace dbTask
{
    /// <summary>
    /// Customer Entity.
    /// </summary>
    [DataContract]
    public class Customer : IEntity
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember]
        public long Id { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [DataMember]
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        [DataMember]
        public string Address { get; private set; }

        /// <summary>
        /// Gets the district.
        /// </summary>
        /// <value>The district.</value>
        [DataMember]
        public string District { get; private set; }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <value>The city.</value>
        [DataMember]
        public string City { get; private set; }

        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <value>The country.</value>
        [DataMember]
        public string Country { get; private set; }

        /// <summary>
        /// Gets the index of the postal.
        /// </summary>
        /// <value>The index of the postal.</value>
        [DataMember]
        public string PostalIndex { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.Customer"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="name">Name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="address">Address.</param>
        /// <param name="district">District.</param>
        /// <param name="city">City.</param>
        /// <param name="country">Country.</param>
        /// <param name="postalIndex">Postal index.</param>
        public Customer(long id, string name, string lastName, string address, string district, string city,
            string country,
            string postalIndex)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Address = address;
            this.District = district;
            this.Country = country;
            this.PostalIndex = postalIndex;
            this.City = city;
        }

        /// <summary>
        /// Determines whether the specified <see cref="dbTask.IEntity"/> is equal to the current <see cref="T:dbTask.Customer"/>.
        /// </summary>
        /// <param name="other">The <see cref="dbTask.IEntity"/> to compare with the current <see cref="T:dbTask.Customer"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="dbTask.IEntity"/> is equal to the current
        /// <see cref="T:dbTask.Customer"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(IEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return other.Id == Id;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:dbTask.Customer"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:dbTask.Customer"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:dbTask.Customer"/>;
        /// otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Customer);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="T:dbTask.Customer"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}