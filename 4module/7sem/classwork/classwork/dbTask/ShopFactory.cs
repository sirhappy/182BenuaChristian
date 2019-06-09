namespace dbTask
{
    /// <summary>
    /// Shop factory.
    /// </summary>
    public class ShopFactory : ITestEntityFactory<Shop>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.ShopFactory"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="city">City.</param>
        /// <param name="country">Country.</param>
        /// <param name="phoneNumber">Phone number.</param>
        public ShopFactory(string name, string city, string country, string phoneNumber)
        {
            _name = name;
            _city = city;
            _country = country;
            _phoneNumber = phoneNumber;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public override Shop Instance
        {
            get { return new Shop(_lastGeneratedId++, _name, _city, _country, _phoneNumber); }
        }

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The city.
        /// </summary>
        private readonly string _city;

        /// <summary>
        /// The country.
        /// </summary>
        private readonly string _country;

        /// <summary>
        /// The phone number.
        /// </summary>
        private readonly string _phoneNumber;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => _name;

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City => _city;

        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country => _country;

        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber => _phoneNumber;

        /// <summary>
        /// Gets the console prompt.
        /// </summary>
        /// <value>The console prompt.</value>
        public static string ConsolePrompt => "Enter Shops parameters in this format:\n" +
                                              "{name};{city};{country};{phonenumber}\n" +
                                              "example: shop1;city1;country1;phone1";

        /// <summary>
        /// Tries to parse.
        /// </summary>
        /// <returns><c>true</c>, if parse was successfull, <c>false</c> otherwise.</returns>
        /// <param name="repr">Repr.</param>
        /// <param name="factory">Factory.</param>
        public static bool TryParse(string repr, out ShopFactory factory)
        {
            factory = null;
            var split = repr.Split(new[] {';'});
            if (split.Length != 4)
            {
                return false;
            }

            factory = new ShopFactory(split[0], split[1], split[2], split[3]);
            return true;
        }
    }
}