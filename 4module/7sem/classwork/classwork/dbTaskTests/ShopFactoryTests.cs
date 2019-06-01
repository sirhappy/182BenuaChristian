using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class ShopFactoryTests
    {
        string name = "name";
        string city = "city";
        string country = "country";
        string phone = "phone";
        
        [Test]
        public void CheckShopGeneration()
        {
            ShopFactory factory = new ShopFactory(name, city, country, phone);
            var instance = factory.Instance;
            Assert.AreEqual(instance.City, city);
            Assert.AreEqual(instance.Name, name);
            Assert.AreEqual(instance.TelephoneNumber, phone);
            Assert.AreEqual(instance.Country, country);
            Assert.Greater(instance.Id, -1);
        }

        [Test]
        public void CheckShopIdsDiffrent()
        {
            ShopFactory factory = new ShopFactory(name, city, country, phone);
            var instance1 = factory.Instance;
            var instance2 = factory.Instance;
            Assert.AreEqual(instance1.Id + 1, instance2.Id);
        }
    }
}