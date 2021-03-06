using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace dbTask
{
    /// <summary>
    /// Requests factory.
    /// </summary>
    public interface IRequestsFactory
    {
        /// <summary>
        /// Orders by customer with longest name.
        /// </summary>
        /// <returns>The orders by customer with longest name.</returns>
        /// <param name="dataBase">Data base.</param>
        IEnumerable<Good> GetOrdersByCustomerWithLongestName(IDataBase dataBase);


        /// <summary>
        /// Gets the most expensive good category.
        /// </summary>
        /// <returns>The most expensive good category.</returns>
        /// <param name="dataBase">Data base.</param>
        string GetMostExpensiveGoodCategory(IDataBase dataBase);

        /// <summary>
        /// Gets the least sells city.
        /// </summary>
        /// <returns>The least sells city.</returns>
        /// <param name="dataBase">Data base.</param>
        string GetLeastSellsCity(IDataBase dataBase);

        /// <summary>
        /// Gets the customers last name who bought most popular good.
        /// </summary>
        /// <returns>The customers last name who bought most popular good.</returns>
        /// <param name="dataBase">Data base.</param>
        IEnumerable<string> GetCustomersLastNameWhoBoughtMostPopularGood(IDataBase dataBase);

        /// <summary>
        /// Gets the shops amount in country with least amount of shops.
        /// </summary>
        /// <returns>The shops amount in country with least amount of shops.</returns>
        /// <param name="dataBase">Data base.</param>
        int GetShopsAmountInCountryWithLeastAmountOfShops(IDataBase dataBase);

        /// <summary>
        /// Gets the orders in foreign city.
        /// </summary>
        /// <returns>The orders in foreign city.</returns>
        /// <param name="dataBase">Data base.</param>
        IEnumerable<Order> GetOrdersInForeignCity(IDataBase dataBase);

        /// <summary>
        /// Gets all orders sum.
        /// </summary>
        /// <returns>The all orders sum.</returns>
        /// <param name="dataBase">Data base.</param>
        double GetAllOrdersSum(IDataBase dataBase);
    }

    /// <summary>
    /// Requests factory.
    /// </summary>
    public class RequestsFactory : IRequestsFactory
    {
        //throws InvOp
        /// <summary>
        /// Gets the name of the orders by customer with longest name.
        /// </summary>
        /// <returns>The orders by customer with longest name.</returns>
        /// <param name="dataBase">Data base.</param>
        public IEnumerable<Good> GetOrdersByCustomerWithLongestName(IDataBase dataBase)
        {
            int maxNameLen = dataBase.Table<Customer>().Select(el => el.Name.Length).Max();
            var customer = dataBase.Table<Customer>().First(el => el.Name.Length == maxNameLen);
            var good = dataBase.Table<Order>().Where(order => order.CustomerId == customer.Id)
                .Select(order => order.GoodId)
                .Select(goodId => dataBase.Table<Good>().FirstOrDefault(el => el.Id == goodId))
                .Where(el => !(el is null));
            return good;
        }

        //throws
        /// <summary>
        /// Gets the most expensive good category.
        /// </summary>
        /// <returns>The most expensive good category.</returns>
        /// <param name="dataBase">Data base.</param>
        public string GetMostExpensiveGoodCategory(IDataBase dataBase)
        {
            double maxCost = dataBase.Table<Order>().Select(el => el.GoodCost).Max();
            var order = dataBase.Table<Order>().ToList().First(el => Math.Abs(el.GoodCost - maxCost) < 1e-9);
            long index = order.GoodId;
            var good = dataBase.Table<Good>().FirstOrDefault(el => el.Id == index);
            if (good is null)
            {
                throw new DataException($"Invalid database content, no good with id={index}");
            }

            return good.Category;
        }

        /// <summary>
        /// Gets the least sells city.
        /// </summary>
        /// <returns>The least sells city.</returns>
        /// <param name="dataBase">Data base.</param>
        public string GetLeastSellsCity(IDataBase dataBase)
        {
            var city = dataBase.Table<Order>().Select(el =>
                {
                    var shp = dataBase.Table<Shop>().FirstOrDefault(shop => shop.Id == el.ShopId);
                    if (shp is null)
                    {
                        throw new DataBaseException($"No shop found with id={el.ShopId} from order");
                    }

                    return new
                    {
                        City = shp.City,
                        Country = shp.Country,
                        OrderCost = el.GoodCost * el.GoodAmount
                    };
                })
                .GroupBy(el => (el.City, el.Country))
                .Select(el => new {City = el.Key.Item1, TotalCosts = el.Sum(orderCost => orderCost.OrderCost)})
                .OrderBy(el => el.TotalCosts).FirstOrDefault();
            if (city is null)
            {
                throw new DataBaseException("Invalid database content, orders Table is empty");
            }

            return city.City;
        }

        /// <summary>
        /// Gets the customers last name who bought most popular good.
        /// </summary>
        /// <returns>The customers last name who bought most popular good.</returns>
        /// <param name="dataBase">Data base.</param>
        public IEnumerable<string> GetCustomersLastNameWhoBoughtMostPopularGood(IDataBase dataBase)
        {
            var foundedOrder = dataBase.Table<Order>().GroupBy(el => el.GoodId).Select(el => new
            {
                GoodId = el.Key,
                SellsCount = el.Select(order => order.GoodAmount).Sum()
            }).OrderByDescending(el => el.SellsCount).FirstOrDefault();

            if (foundedOrder is null)
            {
                throw new DataBaseException("Invalid Db content, no order");
            }

            long goodId = foundedOrder.GoodId;
            return dataBase.Table<Order>().Where(order => order.GoodId == goodId).Select(order => order.CustomerId)
                .Select(customerId => dataBase.Table<Customer>().FirstOrDefault(customer => customer.Id == customerId))
                .Where(customer => !(customer is null))
                .Select(customer => customer.LastName).Distinct();
        }

        /// <summary>
        /// Gets the shops amount in country with least amount of shops.
        /// </summary>
        /// <returns>The shops amount in country with least amount of shops.</returns>
        /// <param name="dataBase">Data base.</param>
        public int GetShopsAmountInCountryWithLeastAmountOfShops(IDataBase dataBase)
        {
            var countryShop = dataBase.Table<Shop>().GroupBy(shop => shop.Country).Select(groupByCountry =>
                    new {Country = groupByCountry.Key, ShopsCnt = groupByCountry.Count()})
                .OrderBy(el => el.ShopsCnt).FirstOrDefault();
            return countryShop?.ShopsCnt ?? 0;
        }

        /// <summary>
        /// Gets the orders in foreign city.
        /// </summary>
        /// <returns>The orders in foreign city.</returns>
        /// <param name="dataBase">Data base.</param>
        public IEnumerable<Order> GetOrdersInForeignCity(IDataBase dataBase)
        {
            return dataBase.Table<Order>().Where(order =>
            {
                var neededCustomer = dataBase.Table<Customer>().FirstOrDefault(el => el.Id == order.CustomerId);
                if (neededCustomer is null)
                {
                    throw new DataBaseException("Invalid db content, didnt found user for order");
                }

                var customerCity = neededCustomer.City;
                var customerCountry = neededCustomer.Country;

                var neededShop = dataBase.Table<Shop>().FirstOrDefault(el => el.Id == order.ShopId);
                if (neededShop is null)
                {
                    throw new DataBaseException("Invalid db content, no shop found for order.ShopId");
                }

                var shopCity = neededShop.City;
                var shopCountry = neededShop.Country;

                return !(customerCity == shopCity && shopCountry == customerCountry);
            });
        }

        /// <summary>
        /// Gets all orders sum.
        /// </summary>
        /// <returns>The all orders sum.</returns>
        /// <param name="dataBase">Data base.</param>
        public double GetAllOrdersSum(IDataBase dataBase)
        {
            return dataBase.Table<Order>().Select(order => order.GoodCost * order.GoodAmount).Sum();
        }
    }
}