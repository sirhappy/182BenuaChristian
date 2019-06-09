using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace dbTask
{
    public class DataBase : ICloneable
    {
        /// <summary>
        /// The database tables.
        /// </summary>
        private readonly IDictionary<Type, List<IEntity>> _tables;

        /// <summary>
        /// The serialization factory.
        /// </summary>
        private CollectionSerializationFactory _serializationFactory;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.DataBase"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="factory">Factory.</param>
        public DataBase(string name, CollectionSerializationFactory factory)
        {
            Name = name;
            _serializationFactory = factory;
            _tables = new Dictionary<Type, List<IEntity>>();
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <typeparam name="T">The type of table to be created.</typeparam>
        public void CreateTable<T>() where T : IEntity
        {
            if (_tables.ContainsKey(typeof(T)))
            {
                throw new DataBaseException();
            }

            _tables[typeof(T)] = new List<IEntity>();
        }

        /// <summary>
        /// Creates the table without throwing an exception.
        /// </summary>
        /// <typeparam name="T">The type of table to be created</typeparam>
        public void CreateTableNoThrow<T>() where T : IEntity
        {
            if (!_tables.ContainsKey(typeof(T)))
            {
                _tables[typeof(T)] = new List<IEntity>();
            }
        }

        /// <summary>
        /// Clears the table.
        /// </summary>
        /// <typeparam name="T">Type of table to be cleared</typeparam>
        private void ClearTable<T>()
        {
            _tables[typeof(T)].Clear();
        }

        /// <summary>
        /// Fills the table.
        /// </summary>
        /// <param name="data">Data.</param>
        /// <typeparam name="T">Type of table to be filled</typeparam>
        private void FillTable<T>(IEnumerable<IEntity> data)
        {
            _tables[typeof(T)].AddRange(data);
        }

        /// <summary>
        /// Inserts entity into.
        /// </summary>
        /// <param name="factory">Factory.</param>
        /// <typeparam name="T">The type of table to be inserted to</typeparam>
        public void InsertInto<T>(IEntityFactory<T> factory) where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            (_tables[tableType]).Add(factory.Instance);
        }

        /// <summary>
        /// Gets the content of table.
        /// </summary>
        /// <returns>The table.</returns>
        /// <typeparam name="T">The type of table to be got.</typeparam>
        public IEnumerable<T> Table<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            return _tables[tableType].Cast<T>();
        }

        /// <summary>
        /// Serialize the specified prefix and fileName.
        /// </summary>
        /// <param name="prefix">Prefix.</param>
        /// <param name="fileName">File name.</param>
        /// <typeparam name="T">Type of table to be serialized.</typeparam>
        public void Serialize<T>(string prefix = "", string fileName = null) where T : IEntity
        {
            fileName = "../../" + (fileName ?? "DB" + typeof(T).Name.Split('.').Last() + prefix + ".json");
            _serializationFactory.JsonCollectionSerializer<T>().Serializer
                .Serialize(fileName, _tables[typeof(T)].Cast<T>());
        }

        /// <summary>
        /// Restores the data table.
        /// </summary>
        /// <param name="prefix">Prefix.</param>
        /// <param name="fileName">File name.</param>
        /// <typeparam name="T">Type of table to be restored.</typeparam>
        public void RestoreDataTable<T>(string prefix = "", string fileName = null) where T : IEntity
        {
            this.CreateTableNoThrow<T>();
            fileName = "../../" + (fileName ?? "DB" + typeof(T).Name.Split('.').Last() + prefix + ".json");
            ClearTable<T>();
            FillTable<T>(this._serializationFactory.JsonCollectionSerializer<T>().Deserialize(fileName)
                .Cast<IEntity>());
        }

        /// <summary>
        /// Clear this instance.
        /// </summary>
        /// <typeparam name="T">Type of table to be cleared.</typeparam>
        public void Clear<T>() where T : IEntity
        {
            _tables.Remove(typeof(T));
        }

        /// <summary>
        /// Clears all content of db.
        /// </summary>
        public void ClearAll()
        {
            _tables.Clear();
        }

        /// <summary>
        /// Creates all tabled.
        /// </summary>
        public void CreateAll()
        {
            this.CreateTableNoThrow<Shop>();
            this.CreateTableNoThrow<Order>();
            this.CreateTableNoThrow<Customer>();
            this.CreateTableNoThrow<Good>();
        }

        /// <summary>
        /// Rolls back the database state.
        /// </summary>
        /// <param name="checkPoint">Check point.</param>
        public void RollBack(DataBase checkPoint)
        {
            this.ClearAll();
            this.CreateAll();
            foreach (var el in checkPoint._tables)
            {
                this._tables[el.Key].AddRange(el.Value);
            }
        }

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <returns>The clone.</returns>
        public object Clone()
        {
            var dataBase = new DataBase("MyDB", this._serializationFactory);
            dataBase.CreateAll();
            foreach (var el in this._tables)
            {
                dataBase._tables[el.Key].AddRange(el.Value);
            }

            return dataBase;
        }
    }
}