using System.Collections.Generic;

namespace dbTask
{
    public class OrderFactory: ITestEntityFactory<Order>
    {
        public override Order Instance => new Order(_lastGeneratedId++, _customerId, _shopId, _goodId,
            _goodAmount, _goodCost);
        
        private long _customerId;

        private long _shopId;

        private long _goodId;

        private int _goodAmount;

        private double _goodCost;

        public OrderFactory(long customerId, long shopId, long goodId,
            int goodAmount, double goodCost)
        {
            _customerId = customerId;
            _shopId = shopId;
            _goodId = goodId;
            _goodAmount = goodAmount;
            _goodCost = goodCost;
        }
    }
}