namespace dbTask
{
    public class GoodFactory : ITestEntityFactory<Good>
    {
        public override Good Instance => new Good(_lastGeneratedId++, _name, _description, _category);

        private readonly string _name;

        private readonly string _description;

        private readonly string _category;

        public GoodFactory(string name, string description, string category)
        {
            _name = name;
            _description = description;
            _category = category;
        }

        public string Name => _name;

        public string Description => _description;

        public string Category => _category;

        public static bool TryParse(string repr, out GoodFactory good)
        {
            var split = repr.Split(new[] {';'});
            good = null;
            if (split.Length != 3)
            {
                return false;
            }

            good = new GoodFactory(split[0], split[1], split[2]);
            return true;
        }

        public static string ConsolePrompt => "Enter Good parameters in this format:\n" +
                                              "{name};{description};{category}\n" +
                                              "Example: good1;desc1;cat1";
    }
}