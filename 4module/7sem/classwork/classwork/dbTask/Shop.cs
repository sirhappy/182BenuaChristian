using System;
using System.Runtime.Serialization;

namespace dbTask
{
    /// <summary>
    /// Shop.
    /// </summary>
    [DataContract]
    public class Shop : IEntity
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
        /// Gets the telephone number.
        /// </summary>
        /// <value>The telephone number.</value>
        [DataMember]
        public string TelephoneNumber { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.Shop"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="name">Name.</param>
        /// <param name="city">City.</param>
        /// <param name="country">Country.</param>
        /// <param name="phoneNumber">Phone number.</param>
        public Shop(long id, string name, string city, string country, string phoneNumber)
        {
            Id = id;
            Name = name;
            City = city;
            Country = country;
            TelephoneNumber = phoneNumber;
        }

        /// <summary>
        /// Determines whether the specified <see cref="dbTask.IEntity"/> is equal to the current <see cref="T:dbTask.Shop"/>.
        /// </summary>
        /// <param name="other">The <see cref="dbTask.IEntity"/> to compare with the current <see cref="T:dbTask.Shop"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="dbTask.IEntity"/> is equal to the current
        /// <see cref="T:dbTask.Shop"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(IEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:dbTask.Shop"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:dbTask.Shop"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:dbTask.Shop"/>;
        /// otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Shop);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="T:dbTask.Shop"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}