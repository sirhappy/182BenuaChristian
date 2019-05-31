namespace dbTask
{
    public class GoodFactory: IEntityFactory<Good>
    {
        private static long _lastGeneratedId = 0;
        public Good Instance => new Good(_lastGeneratedId++, _name, _shopId, _description, _category);

        private string _name;

        private string _description;

        private long _shopId;

        private string _category;

        public GoodFactory(string name, long shopId, string description, string category)
        {
            _name = name;
            _shopId = shopId;
            _description = description;
            _category = category;
        }
    }
}