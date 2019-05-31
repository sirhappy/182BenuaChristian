using System;
using System.Collections.Generic;
using System.Linq;

namespace dbTask
{

    public interface IRequestsFactory
    {
        IEnumerable<Order> OrdersByCustomerWithLongestName(DataBase dataBase);

        string MostExpensiveGoodCategory(DataBase dataBase);
    }
    
    public class RequestsFactory: IRequestsFactory
    {
        public IEnumerable<Order> OrdersByCustomerWithLongestName(DataBase dataBase)
        {
            int maxNameLen = dataBase.Table<Customer>().Select(el => el.Name.Length).Max();
            var customer = dataBase.Table<Customer>().First(el => el.Name.Length == maxNameLen);
            return dataBase.Table<Order>().Where(el => el.CustomerIds.Contains(customer.Id));
        }

        public string MostExpensiveGoodCategory(DataBase dataBase)
        {
            double maxCost = dataBase.Table<Order>().Select(el => el.GoodsCosts.Max()).Max();
            var order = dataBase.Table<Order>().ToList().First(el => el.GoodsCosts.Max() == maxCost);
            int index = order.GoodsCosts.IndexOf(maxCost);

            return index == -1
                ? "Not Found"
                : dataBase.Table<Good>().First(el => el.Id == order.GoodIds[index]).Category;
        }
    }
}