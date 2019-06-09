using System;

namespace dbTask
{
    /// <summary>
    /// Data base exception.
    /// </summary>
    public class DataBaseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.DataBaseException"/> class.
        /// </summary>
        public DataBaseException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.DataBaseException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public DataBaseException(string message) : base(message)
        {
        }
    }
}