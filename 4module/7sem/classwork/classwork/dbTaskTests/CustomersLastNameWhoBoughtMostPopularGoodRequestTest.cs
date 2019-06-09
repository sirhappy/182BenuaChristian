using System.Collections.Generic;
using System.Linq;
using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class CustomersLastNameWhoBoughtMostPopularGoodRequestTest
    {
        private CoreAssembly _assembly;

        [SetUp]
        public void SetUp()
        {
            _assembly = new CoreAssembly();
            CoreAssembly.PrepareForTest();
        }

        public void Clear()
        {
            _assembly.MyDataBase.ClearAll();
        }

        public void DummyFill()
        {
            _assembly.MyDataBase.CreateTable<Shop>();
            _assembly.MyDataBase.CreateTable<Good>();
            _assembly.MyDataBase.CreateTable<Order>();
            _assembly.MyDataBase.CreateTable<Customer>();

            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("name1", "city1", "country1", "phone1"));
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc1", "cat1"));
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good2", "desc2", "cat2"));

            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer1", "1", "address1",
                "district1", "city1", "country1", "postalIndex1"));
            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer2", "2", "address2",
                "district2", "city2", "country2", "postal2"));
            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer3", "3", "address3", "district3",
                "city3", "country3", "postal3"));
            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer4", "4", "address4", "district4",
                "city4", "country4", "postal4"));

            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, 20, 10));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(1, 0, 0, 20, 10));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(2, 0, 1, 39, 10));
        }

        [Test]
        public void TestLastNamesRequest()
        {
            Clear();
            DummyFill();

            IEnumerable<string> result = null;

            Assert.DoesNotThrow(() =>
            {
                result =
                    _assembly.RequestsFactory.GetCustomersLastNameWhoBoughtMostPopularGood(_assembly.MyDataBase);
            });

            Assert.True(result.OrderBy(el => el).SequenceEqual(new string[] {"1", "2"}));
        }
    }
}