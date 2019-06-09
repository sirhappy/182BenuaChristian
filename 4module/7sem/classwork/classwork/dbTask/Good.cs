using System.Runtime.Serialization;

namespace dbTask
{
    /// <summary>
    /// Good.
    /// </summary>
    [DataContract]
    public class Good : IEntity
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
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember]
        public string Description { get; private set; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>The category.</value>
        [DataMember]
        public string Category { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.Good"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="category">Category.</param>
        public Good(long id, string name, string description, string category)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:dbTask.Good"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:dbTask.Good"/>.</returns>
        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Descr:{Description}, Category:{Category}";
        }

        /// <summary>
        /// Determines whether the specified <see cref="dbTask.IEntity"/> is equal to the current <see cref="T:dbTask.Good"/>.
        /// </summary>
        /// <param name="other">The <see cref="dbTask.IEntity"/> to compare with the current <see cref="T:dbTask.Good"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="dbTask.IEntity"/> is equal to the current
        /// <see cref="T:dbTask.Good"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(IEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:dbTask.Good"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:dbTask.Good"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:dbTask.Good"/>;
        /// otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Good);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="T:dbTask.Good"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}