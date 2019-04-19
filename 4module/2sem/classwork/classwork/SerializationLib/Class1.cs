using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SerializationLib
{
    public interface ISerializer<T>
    {
        void Serialize(string fileName, T serializableObject, Type[] knwonTypes = null);
    }

    public interface IDeserializer<T>
    {
        T Deserialize(string fileName, Type[] knownTypes = null);
    }
    
    public class JSONCollectionSerializer<T> : ISerializer<T[]>
    {

        private Type[] knownTypes;

        public JSONCollectionSerializer()
        {
            
        }

        public JSONCollectionSerializer(Type[] knownTypes)
        {
            this.knownTypes = knownTypes;
        }
        
        public void Serialize(string fileName, T[] serializableObject, Type[] extraTypes = null)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer serializer = null;
                if (this.knownTypes != null || extraTypes != null)
                {
                    serializer = new DataContractJsonSerializer(typeof(T[]), this.knownTypes ?? extraTypes);
                }
                else
                {
                    serializer = new DataContractJsonSerializer(typeof(T[]));
                }
                serializer.WriteObject(fileStream, serializableObject);
            }
        }
    }
    
    public class JSONCollectionDeserializer<T> : IDeserializer<T[]>
    {
        
        private Type[] knownTypes;

        public JSONCollectionDeserializer()
        {
            
        }

        public JSONCollectionDeserializer(Type[] knownTypes)
        {
            this.knownTypes = knownTypes;
        }
        public T[] Deserialize(string fileName, Type[] extraTypes = null)
        {
            T[] deserializedObject = new T[] { };

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                DataContractJsonSerializer serializer = null;
                if (this.knownTypes != null || extraTypes != null)
                {
                    serializer = new DataContractJsonSerializer(typeof(T[]), this.knownTypes ?? extraTypes);
                }
                else
                {
                    serializer = new DataContractJsonSerializer(typeof(T[]));
                }

                deserializedObject =  (T[])serializer.ReadObject(fileStream);
            }

            return deserializedObject;
        }
    }
}