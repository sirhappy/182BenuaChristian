namespace dbTask
{
    public class ShopFactory: IEntityFactory<Shop>
    {

        public ShopFactory(string name, string city, string country, string phoneNumber)
        {
            _name = name;
            _city = city;
            _country = country;
            _phoneNumber = phoneNumber;
        }
        
        public Shop Instance
        {
            get
            {
                return new Shop(_lastGeneratedId++, _name, _city, _country, _phoneNumber);
            }
        }

        private string _name;

        private string _city;

        private string _country;

        private string _phoneNumber;
        
        private static long _lastGeneratedId = 0;
    }
}