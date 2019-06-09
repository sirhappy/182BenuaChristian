using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace dbTask
{
    /// <summary>
    /// Factory correctness checker.
    /// </summary>
    public class FactoryCorrectnessChecker
    {
        /// <summary>
        /// The correctness rules.
        /// </summary>
        private IDictionary<Type, Func<object, bool>> _correctnessRules;

        /// <summary>
        /// The data base.
        /// </summary>
        private DataBase _dataBase;

        /// <summary>
        /// The length of the common max.
        /// </summary>
        private int _commonMaxLen = 40;

        /// <summary>
        /// The length of the desc max.
        /// </summary>
        private int _descMaxLen = 400;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.FactoryCorrectnessChecker"/> class.
        /// </summary>
        /// <param name="dataBase">Data base.</param>
        public FactoryCorrectnessChecker(DataBase dataBase)
        {
            _dataBase = dataBase;
            _correctnessRules = new Dictionary<Type, Func<object, bool>>();
            _correctnessRules[typeof(OrderFactory)] = (object objOrder) =>
            {
                var order = objOrder as OrderFactory;
                if (order is null)
                {
                    throw new InvalidCastException("Cant cast object to orderFactory in FactoryCorrectnessChecker");
                }

                return order.ShopId < _dataBase.Table<Shop>().Count() &&
                       order.CustomerId < dataBase.Table<Customer>().Count() &&
                       order.GoodId < dataBase.Table<Good>().Count();
            };

            _correctnessRules[typeof(ShopFactory)] = (object objShop) =>
            {
                var shopFactory = objShop as ShopFactory;
                if (shopFactory is null)
                {
                    throw new InvalidCastException("Cant cast object to shopFactory in FactoryCorrectnessChecker");
                }

                return shopFactory.City.Length <= _commonMaxLen && shopFactory.Country.Length <= _commonMaxLen &&
                       shopFactory.Name.Length <= _commonMaxLen && shopFactory.PhoneNumber.Length <= _commonMaxLen;
            };

            _correctnessRules[typeof(GoodFactory)] = (object goodFactoryObject) =>
            {
                var goodFactory = goodFactoryObject as GoodFactory;
                if (goodFactory is null)
                {
                    throw new InvalidCastException("Cant cast object to GoodFactory in FactoryCorrectnessChecker");
                }

                return goodFactory.Category.Length <= _commonMaxLen && goodFactory.Description.Length <= _descMaxLen &&
                       goodFactory.Name.Length <= _commonMaxLen;
            };

            _correctnessRules[typeof(CustomerFactory)] = (object customerFactoryObj) =>
            {
                var customerFactory = customerFactoryObj as CustomerFactory;
                if (customerFactory is null)
                {
                    throw new InvalidCastException("Cant cast object to customerFactory in FactoryCorrectnessChecker");
                }

                return customerFactory.Address.Length <= _commonMaxLen &&
                       customerFactory.City.Length <= _commonMaxLen &&
                       customerFactory.Country.Length <= _commonMaxLen &&
                       customerFactory.Name.Length <= _commonMaxLen &&
                       customerFactory.LastName.Length <= _commonMaxLen &&
                       customerFactory.PostalIndex.Length <= _commonMaxLen &&
                       customerFactory.District.Length <= _commonMaxLen;
            };
        }

        /// <summary>
        /// Validates the factory.
        /// </summary>
        /// <returns><c>true</c>, if factory was valid, <c>false</c> otherwise.</returns>
        /// <param name="factory">Factory.</param>
        /// <typeparam name="T">The type of factory to be checked.</typeparam>
        /// <typeparam name="U">The type of entity factory produces</typeparam>
        public bool IsValid<T, U>(T factory) where T : IEntityFactory<U> where U : IEntity
        {
            return _correctnessRules[typeof(T)](factory);
        }
    }
}