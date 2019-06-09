using System;

namespace dbTask
{
    /// <summary>
    /// Entity.
    /// </summary>
    public interface IEntity : IEquatable<IEntity>
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        long Id { get; }
    }
}