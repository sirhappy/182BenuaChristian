using System;
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

        private void Clear()
        {
            _assembly.MyDataBase.ClearAll();
            CoreAssembly.PrepareForTest();
        }

        public double DummyFill()
        {
            _assembly.MyDataBase.CreateTable<Order>();
            double totalCost = 0;
            for (int i = 0; i < 100; ++i)
            {
                totalCost += i * i;
                _assembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0, 0, i, i));
            }

            return totalCost;
        }

        [Test]
        public void TestSumOfOrders()
        {
            Clear();
            double rightCost = DummyFill();
            double result = 0;
            Assert.DoesNotThrow(() => { result = _assembly.RequestsFactory.GetAllOrdersSum(_assembly.MyDataBase); });

            Assert.AreEqual(rightCost, result, 1e-5);
        }
    }
}