using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;

namespace dbTask
{
    /// <summary>
    /// Try catch wrapper.
    /// </summary>
    public static class TryCatchWrapper
    {
        /// <summary>
        /// Wraps the linq request.
        /// </summary>
        /// <param name="action">Action.</param>
        public static void WrapLinqRequest(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (DataBaseException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Cant execute your request: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Wraps the serialization request.
        /// </summary>
        /// <param name="action">Action.</param>
        public static void WrapSerializationRequest(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Wraps the deserialization request.
        /// </summary>
        /// <param name="action">Action.</param>
        public static void WrapDeserializationRequest(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Wraps the insert into db request.
        /// </summary>
        /// <param name="action">Action.</param>
        public static void WrapInsertIntoDbRequest(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (DataBaseException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}