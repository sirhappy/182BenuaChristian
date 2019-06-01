namespace dbTask
{
    public class CustomerFactory : ITestEntityFactory<Customer>
    {
        public override Customer Instance => new Customer(_lastGeneratedId++, _name, _lastName, _address, _district, _city, _country, _postalIndex);

        private string _name;

        private string _lastName;

        public CustomerFactory(string name, string lastName, string address, string district, string city, string country, string postalIndex)
        {
            _name = name;
            _lastName = lastName;
            _address = address;
            _district = district;
            _country = country;
            _postalIndex = postalIndex;
            _city = city;
        }

        private string _address;

        private string _district;

        private string _country;

        private string _postalIndex;

        private string _city;
        
    }
}