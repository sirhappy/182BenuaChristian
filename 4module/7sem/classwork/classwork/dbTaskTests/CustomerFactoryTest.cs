using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class CustomerFactoryTest
    {
        private string name = "name";
        private string lastName = "lastName";
        private string address = "address";
        private string district = "district";
        private string city = "city";
        private string country = "country";
        private string postalIndex = "postalIndex";
        
        [Test]
        public void CheckCustomerGeneration()
        {
            var factory = new CustomerFactory(name, lastName, address, district, city, country, postalIndex);
            var instance = factory.Instance;
            
            Assert.NotNull(instance);
            Assert.AreEqual(instance.Name, name);
            Assert.AreEqual(instance.LastName, lastName);
            Assert.AreEqual(instance.Address, address);
            Assert.AreEqual(instance.District, district);
            Assert.AreEqual(instance.City, city);
            Assert.AreEqual(instance.Country, country);
            Assert.AreEqual(instance.PostalIndex, postalIndex);
        }

        [Test]
        public void CheckCustomerIdsDiffrent()
        {
            var factory = new CustomerFactory(name, lastName, address, district, city, country, postalIndex);
            var instance1 = factory.Instance;
            var instance2 = factory.Instance;
            
            Assert.AreNotSame(instance1, instance2);
            Assert.AreNotEqual(instance1.Id, instance2.Id);
            Assert.AreEqual(instance1.Id + 1, instance2.Id);
        }
    }
}