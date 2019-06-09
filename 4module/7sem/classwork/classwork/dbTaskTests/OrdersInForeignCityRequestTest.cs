using System.Collections;
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

        private void Clear()
        {
            _assembly.MyDataBase.ClearAll();
            CoreAssembly.PrepareForTest();
        }

        private void FillDummy()
        {
            _assembly.MyDataBase.CreateAll();

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

        private void FillForDiffCountrySameCity()
        {
            _assembly.MyDataBase.CreateAll();
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc1", "cat1"));

            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("shop1", "city1", "country1", "phone1"));
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("shop2", "city1", "country2", "phone1"));

            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("name1", "lastname1", "address1", "district1",
                "city1", "country1", "postal1"));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, 10, 15));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 1, 0, 10, 15));
        }

        private void FillForThrow()
        {
            Clear();
            _assembly.MyDataBase.CreateAll();

            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, 10, 15));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 1, 0, 10, 15));
        }

        [Test]
        public void TestOrdersInForeignCity()
        {
            Clear();
            FillDummy();

            IEnumerable<Order> result = null;

            Assert.DoesNotThrow(() =>
            {
                result = _assembly.RequestsFactory.GetOrdersInForeignCity(_assembly.MyDataBase);
            });

            Assert.True(result.Select(el => el.Id).OrderBy(id => id).SequenceEqual(new long[] {1, 2}));
        }

        [Test]
        public void TestOrdersInForeignCityWithDiffCountriesAndSameCity()
        {
            Clear();

            _assembly.MyDataBase.CreateAll();

            FillForDiffCountrySameCity();

            IEnumerable<Order> result = null;

            Assert.DoesNotThrow(() =>
            {
                result = _assembly.RequestsFactory.GetOrdersInForeignCity(_assembly.MyDataBase);
            });

            Assert.True(result.Select(order => order.Id).SequenceEqual(new long[] {1}));
        }

        [Test]
        public void TestThrow()
        {
            FillForThrow();

            Assert.Throws<DataBaseException>(() =>
                _assembly.RequestsFactory.GetOrdersInForeignCity(_assembly.MyDataBase).ToList());
        }
    }
}