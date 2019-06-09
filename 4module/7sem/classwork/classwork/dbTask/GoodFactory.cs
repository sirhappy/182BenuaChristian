namespace dbTask
{
    /// <summary>
    /// Good factory.
    /// </summary>
    public class GoodFactory : ITestEntityFactory<Good>
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public override Good Instance => new Good(_lastGeneratedId++, _name, _description, _category);

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The description.
        /// </summary>
        private readonly string _description;

        /// <summary>
        /// The category.
        /// </summary>
        private readonly string _category;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.GoodFactory"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="category">Category.</param>
        public GoodFactory(string name, string description, string category)
        {
            _name = name;
            _description = description;
            _category = category;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => _name;

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description => _description;

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category => _category;

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <returns><c>true</c>, if parse was tryed, <c>false</c> otherwise.</returns>
        /// <param name="repr">Repr.</param>
        /// <param name="good">Good.</param>
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

        /// <summary>
        /// Gets the console prompt.
        /// </summary>
        /// <value>The console prompt.</value>
        public static string ConsolePrompt => "Enter Good parameters in this format:\n" +
                                              "{name};{description};{category}\n" +
                                              "Example: good1;desc1;cat1";
    }
}