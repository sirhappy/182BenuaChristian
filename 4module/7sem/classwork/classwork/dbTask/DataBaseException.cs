using System;

namespace dbTask
{
    public class DataBaseException: Exception
    {
        public DataBaseException()
        {
        }

        public DataBaseException(string message) : base(message)
        {
        }
    }
}