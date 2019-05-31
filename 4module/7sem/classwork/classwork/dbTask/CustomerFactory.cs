namespace dbTask
{
    public class CustomerFactory:IEntityFactory<Customer>
    {
        public Customer Instance => new Customer(_lastGeneratedId++, _name, _lastName, _address, _district, _country, _postalIndex);

        private string _name;

        private string _lastName;

        public CustomerFactory(string name, string lastName, string address, string district, string country, string postalIndex)
        {
            _name = name;
            _lastName = lastName;
            _address = address;
            _district = district;
            _country = country;
            _postalIndex = postalIndex;
        }

        private string _address;

        private string _district;

        private string _country;

        private string _postalIndex;

        private static long _lastGeneratedId = 0;
    }
}