using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class DataBaseContentChecker
    {
        private CoreAssembly _assembly;

        [SetUp]
        public void Setup()
        {
            _assembly = new CoreAssembly();
        }

        private void Clear()
        {
            _assembly.MyDataBase.ClearAll();
            _assembly.MyDataBase.CreateAll();
            CoreAssembly.PrepareForTest();
        }

        private void FillIncorrect()
        {
            Clear();
            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc1", "cat1"));
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("name1", "city1", "country1", "phone1"));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, 10, 20));
        }

        private void FillCorrect()
        {
            Clear();

            _assembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc1", "cat1"));
            _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory("name1", "city1", "country1", "phone1"));
            _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, 10, 20));
            _assembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("man1", "lastname1", "address1", "district1",
                "city1", "country1", "p1"));
        }

        [Test]
        public void TestIncorrectCustomer()
        {
            FillIncorrect();
            Assert.False(_assembly.DataBaseContentChecker.IsValid(_assembly.MyDataBase));
        }

        [Test]
        public void TestCorrectDatabase()
        {
            FillCorrect();
            Assert.True(_assembly.DataBaseContentChecker.IsValid(_assembly.MyDataBase));
        }
    }
}