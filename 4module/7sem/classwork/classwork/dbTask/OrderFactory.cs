using System.Collections.Generic;

namespace dbTask
{
    /// <summary>
    /// Order factory.
    /// </summary>
    public class OrderFactory : ITestEntityFactory<Order>
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public override Order Instance => new Order(_lastGeneratedId++, _customerId, _shopId, _goodId,
            _goodAmount, _goodCost);

        /// <summary>
        /// The customer identifier.
        /// </summary>
        private readonly long _customerId;

        /// <summary>
        /// The shop identifier.
        /// </summary>
        private readonly long _shopId;

        /// <summary>
        /// The good identifier.
        /// </summary>
        private readonly long _goodId;

        /// <summary>
        /// The good amount.
        /// </summary>
        private readonly int _goodAmount;

        /// <summary>
        /// The good cost.
        /// </summary>
        private readonly double _goodCost;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.OrderFactory"/> class.
        /// </summary>
        /// <param name="customerId">Customer identifier.</param>
        /// <param name="shopId">Shop identifier.</param>
        /// <param name="goodId">Good identifier.</param>
        /// <param name="goodAmount">Good amount.</param>
        /// <param name="goodCost">Good cost.</param>
        public OrderFactory(long customerId, long shopId, long goodId,
            int goodAmount, double goodCost)
        {
            _customerId = customerId;
            _shopId = shopId;
            _goodId = goodId;
            _goodAmount = goodAmount;
            _goodCost = goodCost;
        }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public long CustomerId => _customerId;

        /// <summary>
        /// Gets the shop identifier.
        /// </summary>
        /// <value>The shop identifier.</value>
        public long ShopId => _shopId;

        /// <summary>
        /// Gets the good identifier.
        /// </summary>
        /// <value>The good identifier.</value>
        public long GoodId => _goodId;

        public static string ConsolePrompt => "Enter Order parameters in this format:\n" +
                                              "{CustomerId};{ShopId};{GoodId};{GoodAmount};{GoodCost}\n" +
                                              "Example: 0;0;0;1;15.05";

        public static bool TryParse(string repr, out OrderFactory factory)
        {
            factory = null;
            var split = repr.Split(new char[] {';'});
            if (split.Length != 5)
            {
                return false;
            }

            if (long.TryParse(split[0], out var customerId) && long.TryParse(split[1], out var shopId) &&
                long.TryParse(split[2], out var goodId) && int.TryParse(split[3], out var goodAmount) &&
                double.TryParse(split[4], out var goodCost))
            {
                factory = new OrderFactory(customerId, shopId, goodId, goodAmount, goodCost);
                return true;
            }

            return false;
        }
    }
}