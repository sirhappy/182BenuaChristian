using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class JsonSerializationTest
    {
        private CoreAssembly _assembly;


        public void FillSamples()
        {
            _assembly.MyDataBase.CreateTable<Shop>();
            _assembly.MyDataBase.CreateTable<Good>();
            _assembly.MyDataBase.CreateTable<Customer>();
            _assembly.MyDataBase.CreateTable<Order>();

            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop1", "city1", "country1", "phone1"));
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop2", "city2", "country2", "phone2"));
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop3", "city3", "country2", "phone3"));
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop4", "city4", "country2", "phone4"));
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop5", "city5", "country1", "phone5"));


            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc1", "category1"));
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good2", "desc2", "category2"));

            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer1", "lastName1", "address1",
                "district1", "city1", "country1", "postalIndex1"));
            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer22", "lastName2", "address2",
                "district2", "city2", "country2", "postalIndex2"));
            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer3", "lastName3", "address3",
                "district3", "city3", "country3", "postalIndex3"));

            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(1, 0,
                0, 3, 3));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0,
                0, 3, 20));

            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(1, 1,
                1, 5, 3));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(2, 0,
                0, 10, 3));
        }

        public void SerializeAll(string prefix = "")
        {
            _assembly.MyDataBase.Serialize<Good>(prefix);
            _assembly.MyDataBase.Serialize<Shop>(prefix);
            _assembly.MyDataBase.Serialize<Customer>(prefix);
            _assembly.MyDataBase.Serialize<Order>(prefix);
        }

        [SetUp]
        public void SetUp()
        {
            _assembly = new CoreAssembly();
            Console.WriteLine(Directory.GetCurrentDirectory());
            FillSamples();
        }

        [Test]
        public void CheckFilesCreated()
        {
            Assert.DoesNotThrow(() => SerializeAll());

            Assert.True(File.Exists("../../DBCustomer.json"));
            Assert.True(File.Exists("../../DBOrder.json"));
            Assert.True(File.Exists("../../DBShop.json"));
            Assert.True(File.Exists("../../DBGood.json"));
        }

        [Test]
        public void CheckRestoringFromJson()
        {
            SerializeAll();

            DataBase dataBase = new DataBase("TestDB", new CollectionSerializationFactory());
            Assert.DoesNotThrow(() =>
            {
                dataBase.RestoreDataTable<Shop>();
                dataBase.RestoreDataTable<Order>();
                dataBase.RestoreDataTable<Good>();
                dataBase.RestoreDataTable<Customer>();
            });

            Assert.True(dataBase.Table<Shop>().SequenceEqual(_assembly.MyDataBase.Table<Shop>()));
            Assert.True(dataBase.Table<Order>().SequenceEqual(_assembly.MyDataBase.Table<Order>()));
            Assert.True(dataBase.Table<Good>().SequenceEqual(_assembly.MyDataBase.Table<Good>()));
            Assert.True(dataBase.Table<Customer>().SequenceEqual(_assembly.MyDataBase.Table<Customer>()));
        }
    }
}