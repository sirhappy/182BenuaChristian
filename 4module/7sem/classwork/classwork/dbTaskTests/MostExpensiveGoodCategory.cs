using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class MostExpensiveGoodCategory
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

        public void FillDummy()
        {
            _assembly.MyDataBase.CreateTable<Shop>();
            _assembly.MyDataBase.CreateTable<Order>();
            _assembly.MyDataBase.CreateTable<Good>();
            _assembly.MyDataBase.CreateTable<Customer>();

            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("name1", "lastname1", "address1", "district1",
                "city1", "country1", "postalIndex1"));
            
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("shop1", "city1", "country1", "phone1"));
            
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc1", "cat1"));
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good2", "desc2", "cat2"));
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good3", "desc3", "cat3"));
            
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, 10, 20));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 1, 11, 19));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0,0,2,12, 17));
        }

        [Test]
        public void SimpleCategoryRequestTest()
        {
            Clear();
            FillDummy();

            var result = _assembly.RequestsFactory.MostExpensiveGoodCategory(_assembly.MyDataBase);
            Assert.AreEqual(result, "cat1");
        }
    }
}