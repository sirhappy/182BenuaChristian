using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace dbTask
{
    public class Reader
    {
        public static T Read<T>(string In, string Out, Func<T, bool> valid)
        {
            Console.WriteLine(In);
            object[] parameters;
            var methodInfo = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public,
                null, new[] {typeof(string), typeof(T).MakeByRefType()}, null);
            while (!((bool) (methodInfo.Invoke(null, (parameters = new object[]
                         {Console.ReadLine(), null}))) && valid((T) parameters[1])))
            {
                Console.WriteLine(Out);
            }

            return (T) parameters[1];
        }
    }

    internal class Program
    {
        public static void FillSamples(CoreAssembly coreAssembly)
        {
            coreAssembly.MyDataBase.CreateTable<Shop>();
            coreAssembly.MyDataBase.CreateTable<Good>();
            coreAssembly.MyDataBase.CreateTable<Customer>();
            coreAssembly.MyDataBase.CreateTable<Order>();

            coreAssembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop1", "city1", "country1", "phone1"));
            coreAssembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop2", "city2", "country2", "phone2"));
            coreAssembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop3", "city3", "country2", "phone3"));
            coreAssembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop4", "city4", "country2", "phone4"));
            coreAssembly.MyDataBase.InsertInto<Shop>(new ShopFactory("Shop5", "city5", "country1", "phone5"));


            coreAssembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", "desc1", "category1"));
            coreAssembly.MyDataBase.InsertInto<Good>(new GoodFactory("good2", "desc2", "category2"));

            coreAssembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer1", "lastName1", "address1",
                "district1", "city1", "country1", "postalIndex1"));
            coreAssembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer22", "lastName2", "address2",
                "district2", "city2", "country2", "postalIndex2"));
            coreAssembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer3", "lastName3", "address3",
                "district3", "city3", "country3", "postalIndex3"));

            coreAssembly.MyDataBase.InsertInto<Order>(new OrderFactory(1, 0,
                0, 3, 3));
            coreAssembly.MyDataBase.InsertInto<Order>(new OrderFactory(0, 0,
                0, 3, 20));

            coreAssembly.MyDataBase.InsertInto<Order>(new OrderFactory(1, 1,
                1, 5, 3));
            coreAssembly.MyDataBase.InsertInto<Order>(new OrderFactory(2, 0,
                0, 10, 3));

            SerializeAll(coreAssembly);
        }

        public static void FillFromJSON(CoreAssembly coreAssembly)
        {
            coreAssembly.MyDataBase.ClearAll();
            coreAssembly.MyDataBase.RestoreDataTable<Shop>();
            coreAssembly.MyDataBase.RestoreDataTable<Good>();
            coreAssembly.MyDataBase.RestoreDataTable<Customer>();
            coreAssembly.MyDataBase.RestoreDataTable<Order>();

            //checkit
            SerializeAll(coreAssembly, "_TestCheck");
        }

        public static void SerializeAll(CoreAssembly coreAssembly, string prefix = "")
        {
            coreAssembly.MyDataBase.Serialize<Good>(prefix);
            coreAssembly.MyDataBase.Serialize<Shop>(prefix);
            coreAssembly.MyDataBase.Serialize<Customer>(prefix);
            coreAssembly.MyDataBase.Serialize<Order>(prefix);
        }

        public static void TestRequests(CoreAssembly coreAssembly)
        {
            Console.WriteLine(coreAssembly.RequestsFactory.MostExpensiveGoodCategory(coreAssembly.MyDataBase));
            Console.WriteLine();
            foreach (var el in coreAssembly.RequestsFactory.OrdersByCustomerWithLongestName(coreAssembly.MyDataBase))
            {
                Console.WriteLine(el);
            }

            Console.WriteLine();
            Console.WriteLine(coreAssembly.RequestsFactory.LeastSellsCity(coreAssembly.MyDataBase));
            Console.WriteLine();
            foreach (var lastName in coreAssembly.RequestsFactory.CustomersLastNameWhoBoughtMostPopularGood(coreAssembly
                .MyDataBase))
            {
                Console.WriteLine(lastName);
            }

            Console.WriteLine();
            Console.WriteLine(
                coreAssembly.RequestsFactory.ShopsAmountInCountryWithLeastAmountOfShops(coreAssembly.MyDataBase));

            Console.WriteLine();
            foreach (var order in coreAssembly.RequestsFactory.OrdersInForeignCity(coreAssembly.MyDataBase))
            {
                Console.WriteLine(order);
            }

            Console.WriteLine();
            Console.WriteLine(coreAssembly.RequestsFactory.AllOrdersSum(coreAssembly.MyDataBase));
        }

        public static void Main(string[] args)
        {
            CoreAssembly coreAssembly = new CoreAssembly();
            /*
            FillSamples(coreAssembly);
            coreAssembly.MyDataBase.ClearAll();
            FillFromJSON(coreAssembly);
            TestRequests(coreAssembly);
            Console.WriteLine();*/
            ConsoleManager manager = new ConsoleManager(coreAssembly.CorrectnessChecker, coreAssembly.MyDataBase,
                coreAssembly.RequestsFactory);
            manager.StartSession();
        }
    }
}