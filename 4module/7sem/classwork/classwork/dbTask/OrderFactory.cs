using System.Collections.Generic;

namespace dbTask
{
    public class OrderFactory: IEntityFactory<Order>
    {
        public Order Instance => new Order(_lastGeneratedId++, _customersIds, _shopsId, _goodIds,
            _goodsAmounts, _goodsCosts);

        private static long _lastGeneratedId = 0;

        private IList<long> _customersIds;

        private IList<long> _shopsId;

        private IList<long> _goodIds;

        private IList<int> _goodsAmounts;

        private IList<double> _goodsCosts;

        public OrderFactory(IList<long> customersIds, IList<long> shopsId, IList<long> goodIds,
            IList<int> goodsAmounts, IList<double> goodsCosts)
        {
            _customersIds = customersIds;
            _shopsId = shopsId;
            _goodIds = goodIds;
            _goodsAmounts = goodsAmounts;
            _goodsCosts = goodsCosts;
        }
    }
}