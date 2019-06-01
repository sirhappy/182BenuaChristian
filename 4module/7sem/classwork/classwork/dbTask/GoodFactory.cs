namespace dbTask
{
    public class GoodFactory: ITestEntityFactory<Good>
    {
        public override Good Instance => new Good(_lastGeneratedId++, _name, _description, _category);

        private string _name;

        private string _description;


        private string _category;

        public GoodFactory(string name, string description, string category)
        {
            _name = name;
            _description = description;
            _category = category;
        }
    }
}