using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;

namespace dbTask
{
    public static class TryCatchWrapper
    {
        public static void LinqRequestWrapper(Action action)
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

        public static void SerializationRequestWrapper(Action action)
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

        public static void DeserializationWrapper(Action action)
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

        public static void InsertIntoDbRequestWrapper(Action action)
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