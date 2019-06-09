using System.Linq;

namespace dbTask
{
    /// <summary>
    /// Data base content checker.
    /// </summary>
    public interface IDataBaseContentChecker
    {
        bool IsValid(DataBase dataBase);
    }

    /// <summary>
    /// Data base content checker.
    /// </summary>
    public class DataBaseContentChecker : IDataBaseContentChecker
    {
        /// <summary>
        /// Validates database
        /// </summary>
        /// <returns><c>true</c>, if db was valid, <c>false</c> otherwise.</returns>
        /// <param name="dataBase">Data base.</param>
        public bool IsValid(DataBase dataBase)
        {
            return CheckOrders(dataBase);
        }

        /// <summary>
        /// Checks the orders table of db.
        /// </summary>
        /// <returns><c>true</c>, if database has right content, <c>false</c> otherwise.</returns>
        /// <param name="dataBase">Data base.</param>
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