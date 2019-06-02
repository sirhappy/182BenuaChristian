namespace dbTask
{
    public class ShopFactory : ITestEntityFactory<Shop>
    {
        public ShopFactory(string name, string city, string country, string phoneNumber)
        {
            _name = name;
            _city = city;
            _country = country;
            _phoneNumber = phoneNumber;
        }

        public override Shop Instance
        {
            get { return new Shop(_lastGeneratedId++, _name, _city, _country, _phoneNumber); }
        }

        private readonly string _name;

        private readonly string _city;

        private readonly string _country;

        private readonly string _phoneNumber;

        public string Name => _name;

        public string City => _city;

        public string Country => _country;

        public string PhoneNumber => _phoneNumber;

        public static string ConsolePrompt => "Enter Shops parameters in this format:\n" +
                                              "{name};{city};{country};{phonenumber}\n" +
                                              "example: shop1;city1;country1;phone1";

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