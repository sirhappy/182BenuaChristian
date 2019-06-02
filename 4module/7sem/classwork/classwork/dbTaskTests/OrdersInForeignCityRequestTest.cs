using System.Collections.Generic;
using System.Linq;
using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class OrdersInForeignCityRequestTest
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

        public void FillDummy()
        {
            _assembly.MyDataBase.CreateTable<Shop>();
            _assembly.MyDataBase.CreateTable<Order>();
            _assembly.MyDataBase.CreateTable<Customer>();
            _assembly.MyDataBase.CreateTable<Good>();

            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc1", "cat1"));

            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("shop1", "1", "country1", ""));
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("shop2", "2", "country1", ""));

            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer1", "", "address1", "district1", "1",
                "country1", "postalIndex1"));
            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer2", "", "address2", "district2", "2",
                "country1", "postalIndex2"));

            for (int i = 0; i <= 1; ++i)
            {
                for (int j = 0; j <= 1; ++j)
                {
                    _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(i, j, 0, 10 * i + 10 * j + i + j, 10));
                }
            }
        }

        [Test]
        public void TestOrdersInForeignCity()
        {
            Clear();
            FillDummy();

            IEnumerable<Order> result = null;

            Assert.DoesNotThrow(() =>
            {
                result = _assembly.RequestsFactory.OrdersInForeignCity(_assembly.MyDataBase);
            });

            Assert.True(result.Select(el => el.Id).OrderBy(id => id).SequenceEqual(new long[] {1, 2}));
        }
    }
}