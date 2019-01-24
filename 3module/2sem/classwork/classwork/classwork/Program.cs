using System;

namespace classwork
{

    delegate string ConvertRule(string a);

    class Converter
    {
        public string Convert(string source, ConvertRule rule)
        {
            return rule(source);
        }
    }





    class Program
    {

        public static string RemoveDigits(string str)
        {
            for (char el = '0'; el <= '9'; ++el)
            {
                str = str.Replace(new String(el, 1), "");
            }
            return str;
        }

        public static string RemoveSpaces(string str)
        {
            return str.Replace(" ", "");
        }

        static void Main(string[] args)
        {
            string[] arr = { "test 1 2 3 obama", "test       56678 test" };
            Converter conv = new Converter();
            foreach (var el in arr)
            {
                Console.WriteLine(conv.Convert(el, RemoveDigits));
                Console.WriteLine(conv.Convert(el, RemoveSpaces));
            }

            ConvertRule del = RemoveSpaces;
            del += RemoveDigits;

            foreach (var el in arr)
            {
                Console.WriteLine(conv.Convert(el, del));
            }
        }
    }
}
