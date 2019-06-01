using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class LeastSellsCityRequestTest
    {
        private CoreAssembly _assembly;

        [SetUp]
        public void SetUp()
        {
            _assembly = new CoreAssembly();
            ShopFactory.ResetIdsForTests();
            OrderFactory.ResetIdsForTests();
            CustomerFactory.ResetIdsForTests();
            GoodFactory.ResetIdsForTests();
        }

        public void Clear()
        {
            _assembly.MyDataBase.ClearAll();
        }

        public void DummyFill()
        {
            _assembly.MyDataBase.CreateTable<Shop>();
            _assembly.MyDataBase.CreateTable<Order>();
            _assembly.MyDataBase.CreateTable<Good>();
            _assembly.MyDataBase.CreateTable<Customer>();
            
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("shop1", "city1", "country1", "phone1"));
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("shop2", "city2", "country1", "phone2"));

            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("name1", "lastname1", "address1", "district1",
                "city1", "country1", "phone1"));
            
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc", "cat1"));
            
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, 15, 20));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 1, 0, 16, 19));
        }

        [Test]
        public void SimpleLeastSellsRequestTest()
        {
            Clear();
            DummyFill();

            var result = _assembly.RequestsFactory.LeastSellsCity(_assembly.MyDataBase);
            Assert.AreEqual(result, "city1");
        }
    }
}