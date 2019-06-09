using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class GoodFactoryTest
    {
        string name = "name";
        string desc = "desc";
        string category = "category";

        [Test]
        public void CheckGoodGeneration()
        {
            var factory = new GoodFactory(name, desc, category);

            var instance = factory.Instance;
            Assert.NotNull(instance);
            Assert.AreEqual(instance.Name, name);
            Assert.AreEqual(instance.Description, desc);
            Assert.AreEqual(category, instance.Category);
            Assert.Greater(instance.Id, -1);
        }

        [Test]
        public void CheckGoodIdsDiffrent()
        {
            var factory = new GoodFactory(name, desc, category);

            var instance1 = factory.Instance;
            var instance2 = factory.Instance;

            Assert.AreNotSame(instance1, instance2);
            Assert.AreNotEqual(instance1.Id, instance2.Id);
            Assert.AreEqual(instance2.Id, instance1.Id + 1);
        }
    }
}