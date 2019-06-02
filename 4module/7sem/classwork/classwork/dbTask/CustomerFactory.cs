namespace dbTask
{
    public class CustomerFactory : ITestEntityFactory<Customer>
    {
        public override Customer Instance => new Customer(_lastGeneratedId++, _name, _lastName, _address, _district,
            _city, _country, _postalIndex);

        private readonly string _name;

        private readonly string _lastName;

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

        private readonly string _address;

        private readonly string _district;

        private readonly string _country;

        private readonly string _postalIndex;

        private readonly string _city;

        public string Name => _name;

        public string LastName => _lastName;

        public string Address => _address;

        public string Country => _country;

        public string District => _district;

        public string PostalIndex => _postalIndex;

        public string City => _city;

        public static string ConsolePrompt => "Enter Customer parameters in this format:\n" +
                                              "{name};{lastname};{address};{district};{cities};{country};{postalIndex}\n" +
                                              "Example: human1;lastnam1;a1;d1;c1;c1;p1";

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