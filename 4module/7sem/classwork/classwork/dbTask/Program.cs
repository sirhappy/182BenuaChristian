using System;
using System.Collections.Generic;
using System.Linq;

namespace dbTask
{
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
            
            coreAssembly.MyDataBase.InsertInto<Good>(new GoodFactory("good1", 0, "desc1", "category1"));
            coreAssembly.MyDataBase.InsertInto<Good>(new GoodFactory("good2", 1, "desc2", "category2"));
            
            coreAssembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer1", "lastname1", "address1",
                "district1", "country1", "postalIndex1"));
            coreAssembly.MyDataBase.InsertInto<Customer>(new CustomerFactory("customer22", "lastName2", "address2",
                "district2", "country2", "postalIndex2"));
           
           
            coreAssembly.MyDataBase.InsertInto<Order>(new OrderFactory(new List<long>(new long[]{0}), new List<long>(new long[]{0,1}),
                new List<long>(new long[]{0, 1}), new List<int>(new int[]{2, 3}), new List<double>(new double[]{15, 20})));
           
            coreAssembly.MyDataBase.InsertInto<Order>(new OrderFactory(new List<long>(new long[]{1}), new List<long>(new long[]{0,1}),
                new List<long>(new long[]{0, 1}), new List<int>(new int[]{15, 16}), new List<double>(new double[]{1, 2}))); 
           
            SerializeAll(coreAssembly);
        }

        public static void FillFromJSON(CoreAssembly coreAssembly)
        {
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
            foreach (var el in coreAssembly.RequestsFactory.OrdersByCustomerWithLongestName(coreAssembly.MyDataBase))
            {
                Console.WriteLine(el);
            }
        }
        
        public static void Main(string[] args)
        {
            CoreAssembly coreAssembly = new CoreAssembly();
            FillSamples(coreAssembly);
            coreAssembly.MyDataBase.ClearAll();
            FillFromJSON(coreAssembly);
            TestRequests(coreAssembly);
            Console.WriteLine();
        }
    }
}