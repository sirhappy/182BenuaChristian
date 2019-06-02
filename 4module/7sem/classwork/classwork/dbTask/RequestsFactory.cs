using System;
using System.Collections.Generic;
using System.Linq;

namespace dbTask
{
    public interface IRequestsFactory
    {
        IEnumerable<Good> OrdersByCustomerWithLongestName(DataBase dataBase);

        string MostExpensiveGoodCategory(DataBase dataBase);

        string LeastSellsCity(DataBase dataBase);

        IEnumerable<string> CustomersLastNameWhoBoughtMostPopularGood(DataBase dataBase);

        int ShopsAmountInCountryWithLeastAmountOfShops(DataBase dataBase);

        IEnumerable<Order> OrdersInForeignCity(DataBase dataBase);

        double AllOrdersSum(DataBase dataBase);
    }

    public class RequestsFactory : IRequestsFactory
    {
        public IEnumerable<Good> OrdersByCustomerWithLongestName(DataBase dataBase)
        {
            int maxNameLen = dataBase.Table<Customer>().Select(el => el.Name.Length).Max();
            var customer = dataBase.Table<Customer>().First(el => el.Name.Length == maxNameLen);
            return dataBase.Table<Order>().Where(order => order.CustomerId == customer.Id).Select(order => order.GoodId)
                .Select(goodId => dataBase.Table<Good>().First(el => el.Id == goodId));
        }

        public string MostExpensiveGoodCategory(DataBase dataBase)
        {
            double maxCost = dataBase.Table<Order>().Select(el => el.GoodCost).Max();
            var order = dataBase.Table<Order>().ToList().First(el => Math.Abs(el.GoodCost - maxCost) < 1e-9);
            long index = order.GoodId;
            var good = dataBase.Table<Good>().First(el => el.Id == index);
            return good.Category;
        }

        public string LeastSellsCity(DataBase dataBase)
        {
            return dataBase.Table<Order>().Select(el =>
                {
                    var shp = dataBase.Table<Shop>().First(shop => shop.Id == el.ShopId);
                    return new
                    {
                        City = shp.City,
                        Country = shp.Country,
                        OrderCost = el.GoodCost * el.GoodAmount
                    };
                })
                .GroupBy(el => (el.City, el.Country))
                .Select(el => new {City = el.Key.Item1, TotalCosts = el.Sum(orderCost => orderCost.OrderCost)})
                .OrderBy(el => el.TotalCosts).First().City;
        }

        public IEnumerable<string> CustomersLastNameWhoBoughtMostPopularGood(DataBase dataBase)
        {
            long goodId = dataBase.Table<Order>().GroupBy(el => el.GoodId).Select(el => new
            {
                GoodId = el.Key,
                SellsCount = el.Select(order => order.GoodAmount).Sum()
            }).OrderByDescending(el => el.SellsCount).First().GoodId;
            return dataBase.Table<Order>().Where(order => order.GoodId == goodId).Select(order => order.CustomerId)
                .Select(customerId => dataBase.Table<Customer>().First(customer => customer.Id == customerId))
                .Select(customer => customer.LastName).Distinct();
        }

        public int ShopsAmountInCountryWithLeastAmountOfShops(DataBase dataBase)
        {
            return dataBase.Table<Shop>().GroupBy(shop => shop.Country).Select(groupByCountry =>
                    new {Country = groupByCountry.Key, ShopsCnt = groupByCountry.Count()})
                .OrderBy(el => el.ShopsCnt).First().ShopsCnt;
        }

        public IEnumerable<Order> OrdersInForeignCity(DataBase dataBase)
        {
            return dataBase.Table<Order>().Where(order =>
            {
                var neededCustomer = dataBase.Table<Customer>().First(el => el.Id == order.CustomerId);
                var customerCity = neededCustomer.City;
                var customerCountry = neededCustomer.Country;

                var neededShop = dataBase.Table<Shop>().First(el => el.Id == order.ShopId);
                var shopCity = neededShop.City;
                var shopCountry = neededShop.Country;

                return !(customerCity == shopCity && shopCountry == customerCountry);
            });
        }

        public double AllOrdersSum(DataBase dataBase)
        {
            return dataBase.Table<Order>().Select(order => order.GoodCost * order.GoodAmount).Sum();
        }
    }
}