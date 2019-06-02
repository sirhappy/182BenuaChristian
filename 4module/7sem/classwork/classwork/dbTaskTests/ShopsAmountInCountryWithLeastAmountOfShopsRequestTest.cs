using System.Collections.Generic;
using dbTask;
using NUnit.Framework;

namespace dbTaskTests
{
    [TestFixture]
    public class ShopsAmountInCountryWithLeastAmountOfShopsRequestTest
    {
        private CoreAssembly _assembly;

        [SetUp]
        public void SetUp()
        {
            _assembly = new CoreAssembly();
            CoreAssembly.PrepareForTest();
        }

        public void Clear()
        {
            _assembly.MyDataBase.ClearAll();
        }

        public void DummyFill()
        {
            _assembly.MyDataBase.CreateTable<Shop>();
            for (int i = 0; i < 10; ++i)
            {
                _assembly.MyDataBase.InsertInto<Shop>(new ShopFactory($"name{i + 1}", "city1", $"country{1 + i / 7}",
                    ""));
            }
        }

        [Test]
        public void TestShopAmountInCountry()
        {
            Clear();
            DummyFill();

            int result = 0;

            Assert.DoesNotThrow(() =>
            {
                result = _assembly.RequestsFactory.ShopsAmountInCountryWithLeastAmountOfShops(_assembly.MyDataBase);
            });
            Assert.AreEqual(result, 3);
        }
    }
}