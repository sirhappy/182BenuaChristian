using System.Collections.Generic;

namespace dbTask
{
    public class OrderFactory : ITestEntityFactory<Order>
    {
        public override Order Instance => new Order(_lastGeneratedId++, _customerId, _shopId, _goodId,
            _goodAmount, _goodCost);

        private readonly long _customerId;

        private readonly long _shopId;

        private readonly long _goodId;

        private readonly int _goodAmount;

        private readonly double _goodCost;

        public OrderFactory(long customerId, long shopId, long goodId,
            int goodAmount, double goodCost)
        {
            _customerId = customerId;
            _shopId = shopId;
            _goodId = goodId;
            _goodAmount = goodAmount;
            _goodCost = goodCost;
        }

        public long CustomerId => _customerId;

        public long ShopId => _shopId;

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