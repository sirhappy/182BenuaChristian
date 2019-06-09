namespace dbTask
{
    /// <summary>
    /// Customer factory.
    /// </summary>
    public class CustomerFactory : ITestEntityFactory<Customer>
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public override Customer Instance => new Customer(_lastGeneratedId++, _name, _lastName, _address, _district,
            _city, _country, _postalIndex);

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The last name.
        /// </summary>
        private readonly string _lastName;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.CustomerFactory"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="address">Address.</param>
        /// <param name="district">District.</param>
        /// <param name="city">City.</param>
        /// <param name="country">Country.</param>
        /// <param name="postalIndex">Postal index.</param>
        public CustomerFactory(string name, string lastName, string address, string district, string city,
            string country, string postalIndex)
        {
            _name = name;
            _lastName = lastName;
            _address = address;
            _district = district;
            _country = country;
            _postalIndex = postalIndex;
            _city = city;
        }

        /// <summary>
        /// The address.
        /// </summary>
        private readonly string _address;

        /// <summary>
        /// The district.
        /// </summary>
        private readonly string _district;

        /// <summary>
        /// The country.
        /// </summary>
        private readonly string _country;

        /// <summary>
        /// The index of the postal.
        /// </summary>
        private readonly string _postalIndex;

        /// <summary>
        /// The city.
        /// </summary>
        private readonly string _city;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => _name;

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName => _lastName;

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address => _address;

        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country => _country;

        /// <summary>
        /// Gets the district.
        /// </summary>
        /// <value>The district.</value>
        public string District => _district;

        /// <summary>
        /// Gets the index of the postal.
        /// </summary>
        /// <value>The index of the postal.</value>
        public string PostalIndex => _postalIndex;

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City => _city;

        /// <summary>
        /// Gets the console prompt.
        /// </summary>
        /// <value>The console prompt.</value>
        public static string ConsolePrompt => "Enter Customer parameters in this format:\n" +
                                              "{name};{lastname};{address};{district};{cities};{country};{postalIndex}\n" +
                                              "Example: human1;lastnam1;a1;d1;c1;c1;p1";

        /// <summary>
        /// Tries to parse.
        /// </summary>
        /// <returns><c>true</c>, if parse was successful, <c>false</c> otherwise.</returns>
        /// <param name="repr">String representation of entity</param>
        /// <param name="factory">Factory.</param>
        public static bool TryParse(string repr, out CustomerFactory factory)
        {
            var split = repr.Split(new[] {';'});
            factory = null;
            if (split.Length != 7)
            {
                return false;
            }

            factory = new CustomerFactory(split[0], split[1], split[2], split[3], split[4], split[5], split[6]);
            return true;
        }
    }
}