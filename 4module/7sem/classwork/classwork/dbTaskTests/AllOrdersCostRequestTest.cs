using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class AllOrdersCostRequestTest
    {
        private CoreAssembly _assembly;

        [SetUp]
        public void SetUp()
        {
            _assembly = new CoreAssembly();
            CoreAssembly.PrepareForTest();
        }

        public void DummyFill()
        {
            _assembly.MyDataBase.CreateTable<Order>();
            double totalCost = 0;
            for (int i = 0; i < 100; ++i)
            {
                totalCost += i * i;
                _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, i, i));
            }

            double result = 0;

            Assert.DoesNotThrow(() => { result = _assembly.RequestsFactory.AllOrdersSum(_assembly.MyDataBase); });

            Assert.AreEqual(totalCost, result, 1e-5);
        }
    }
}