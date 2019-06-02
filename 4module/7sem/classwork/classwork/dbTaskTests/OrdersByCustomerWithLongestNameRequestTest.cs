using System;
using System.Linq;
using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class OrdersByCustomerWithLongestNameRequestTest
    {
        private CoreAssembly _assembly;

        [SetUp]
        public void SetUp()
        {
            _assembly = new CoreAssembly();
            CoreAssembly.PrepareForTest();
        }

        public void FillDummy()
        {
            _assembly.MyDataBase.CreateTable<Customer>();
            _assembly.MyDataBase.CreateTable<Order>();
            _assembly.MyDataBase.CreateTable<Shop>();
            _assembly.MyDataBase.CreateTable<Good>();


            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("1", "lastname1", "address1", "district1",
                "city1", "country1", "postalIndex"));
            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("22", "lastname2", "address2", "district2",
                "city2", "country2", "postalIndex2"));

            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("shop1", "city1", "country1", "phone1"));

            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc1", "cat1"));
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good2", "desc2", "cat2"));


            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, 15, 20));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(1, 0, 1, 20, 18));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(1, 0, 0, 15, 19));
        }

        public void ClearAll()
        {
            _assembly.MyDataBase.ClearAll();
        }

        [Test]
        public void SimpleRequestTest()
        {
            ClearAll();
            FillDummy();
            IOrderedEnumerable<long> result = null;
            Assert.DoesNotThrow(() => result = _assembly.RequestsFactory
                .OrdersByCustomerWithLongestName(_assembly.MyDataBase)
                .Select(el => el.Id).OrderBy(el => el));

            result.ToList().ForEach(Console.WriteLine);

            Assert.True(result.SequenceEqual(new long[] {0, 1}));
        }
    }
}