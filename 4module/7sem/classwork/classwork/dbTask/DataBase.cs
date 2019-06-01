using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace dbTask
{
    
    public class DataBase
    {
        private readonly IDictionary<Type, List<IEntity>> _tables;

        private CollectionSerializationFactory _serializationFactory;
        public string Name { get; private set; }

        public DataBase(string name, CollectionSerializationFactory factory)
        {
            Name = name;
            _serializationFactory = factory;
            _tables = new Dictionary<Type, List<IEntity>>();
        }

        public void CreateTable<T>() where T : IEntity
        {
            if (_tables.ContainsKey(typeof(T)))
            {
                throw new DataBaseException();
            }
            
            _tables[typeof(T)] = new List<IEntity>();
        }

        public void CreateTableNoThrow<T>() where T : IEntity
        {
            if (!_tables.ContainsKey(typeof(T)))
            {
                _tables[typeof(T)] = new List<IEntity>();
            }
        }

        public void FillTable<T>(IEnumerable<IEntity> data)
        {
            _tables[typeof(T)].AddRange(data);
        }

        public void InsertInto<T>(IEntityFactory<T> factory) where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            (_tables[tableType]).Add(factory.Instance);
        }
        
        public IEnumerable<T> Table<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            return _tables[tableType].Cast<T>();
        }

        public void Serialize<T>(string prefix = "", string fileName = null) where T : IEntity
        {
            fileName = fileName ?? "../../DB" + typeof(T).Name.Split('.').Last() + prefix + ".json";
            _serializationFactory.CollectionSerializer<T>().Serializer.Serialize(fileName, _tables[typeof(T)].Cast<T>());
        }

        public void RestoreDataTable<T>(string prefix = "", string fileName = null) where T : IEntity
        {
            this.CreateTableNoThrow<T>();
            fileName = fileName ?? "../../DB" + typeof(T).Name.Split('.').Last() + prefix + ".json";
            FillTable<T>(this._serializationFactory.CollectionSerializer<T>().Deserialize(fileName).Cast<IEntity>());
        }

        public void Clear<T>() where T : IEntity
        {
            _tables.Remove(typeof(T));
        }
        
        public void ClearAll()
        {
            _tables.Clear();
        }
    }
}