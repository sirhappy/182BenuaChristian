using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class OrderFactoryTest
    {
        private long customerId = 0;
        private long shopId = 0;
        private long goodId = 0;
        private int goodAmount = 10;
        private double goodCost = 15.5;
        
        [Test]
        public void CheckOrderGeneration()
        {
            var factory = new OrderFactory(customerId, shopId, goodId, goodAmount, goodCost);
            var instance = factory.Instance;
            
            Assert.NotNull(instance);
            Assert.AreEqual(instance.CustomerId, customerId);
            Assert.AreEqual(instance.GoodId, goodId);
            Assert.AreEqual(instance.ShopId, shopId);
            Assert.AreEqual(instance.GoodAmount, goodAmount);
            Assert.AreEqual(instance.GoodCost, goodCost, 1e-9);
        }

        [Test]
        public void CheckOrderIdsDiffrent()
        {
            var factory = new OrderFactory(customerId, shopId, goodId, goodAmount, goodCost);
            var instance1 = factory.Instance;
            var instance2 = factory.Instance;
            
            Assert.AreNotSame(instance1, instance2);
            Assert.AreNotEqual(instance1.Id, instance2.Id);
            Assert.AreEqual(instance1.Id + 1, instance2.Id);
        }
    }
}