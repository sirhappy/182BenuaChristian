using System.Linq;

namespace dbTask
{
    public interface IDataBaseContentChecker
    {
        bool IsValid(DataBase dataBase);
    }

    public class DataBaseContentChecker : IDataBaseContentChecker
    {
        public bool IsValid(DataBase dataBase)
        {
            return CheckOrders(dataBase);
        }

        private bool CheckOrders(DataBase dataBase)
        {
            bool ok = true;
            foreach (var order in dataBase.Table<Order>())
            {
                var shopId = order.ShopId;
                var customerId = order.CustomerId;
                var goodId = order.GoodId;

                ok &= dataBase.Table<Shop>().Any(el => el.Id == shopId);
                ok &= dataBase.Table<Customer>().Any(el => el.Id == customerId);
                ok &= dataBase.Table<Good>().Any(el => el.Id == goodId);
            }

            return ok;
        }
    }
}