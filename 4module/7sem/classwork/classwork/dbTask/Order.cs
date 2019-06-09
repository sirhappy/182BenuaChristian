using System.Collections.Generic;
using System.Runtime.Serialization;

namespace dbTask
{
    /// <summary>
    /// Order.
    /// </summary>
    [DataContract]
    public class Order : IEntity
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DataMember]
        public long Id { get; private set; }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [DataMember]
        public long CustomerId { get; private set; }

        /// <summary>
        /// Gets the shop identifier.
        /// </summary>
        /// <value>The shop identifier.</value>
        [DataMember]
        public long ShopId { get; private set; }

        /// <summary>
        /// Gets the good identifier.
        /// </summary>
        /// <value>The good identifier.</value>
        [DataMember]
        public long GoodId { get; private set; }

        /// <summary>
        /// Gets the good amount.
        /// </summary>
        /// <value>The good amount.</value>
        [DataMember]
        public int GoodAmount { get; private set; }

        /// <summary>
        /// Gets the good cost.
        /// </summary>
        /// <value>The good cost.</value>
        [DataMember]
        public double GoodCost { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.Order"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="customerId">Customer identifier.</param>
        /// <param name="shopId">Shop identifier.</param>
        /// <param name="goodId">Good identifier.</param>
        /// <param name="goodAmount">Good amount.</param>
        /// <param name="goodCost">Good cost.</param>
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

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:dbTask.Order"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:dbTask.Order"/>.</returns>
        public override string ToString()
        {
            return $"Id:{Id}, CustomerId:{CustomerId}, ShopId:{ShopId}, GoodId:{GoodId}, GoodAmount:{GoodAmount}, " +
                   $"GoodCost:{GoodCost:F3}";
        }

        /// <summary>
        /// Determines whether the specified <see cref="dbTask.IEntity"/> is equal to the current <see cref="T:dbTask.Order"/>.
        /// </summary>
        /// <param name="other">The <see cref="dbTask.IEntity"/> to compare with the current <see cref="T:dbTask.Order"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="dbTask.IEntity"/> is equal to the current
        /// <see cref="T:dbTask.Order"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(IEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:dbTask.Order"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:dbTask.Order"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="T:dbTask.Order"/>;
        /// otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Order);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="T:dbTask.Order"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}