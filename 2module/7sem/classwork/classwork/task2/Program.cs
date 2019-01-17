using System;

namespace task2
{
    class Program
    {

        public static bool isVowel(char ch) {
            return ch == 'a' || ch == 'e' || ch == 'u' || ch == 'y' || ch == 'o' || ch == 'i';
        }

        public static bool Valid(string source) {
            foreach (var el in source) {
                if (!(char.IsLetter(el) || el == ' ')) {
                    return false;
                }
            }
            return true;
        }

        public static string CreateAbbreviation(string source) {
            if (!Valid(source)) {
                throw new ArgumentException("Not valid string passed as parameter");
            }
            string[] arr = source.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string ans = "";
            for (int i = 0; i < arr.Length; ++i) {
                ans += char.ToUpper(arr[i][0]);
                if (isVowel(char.ToLower(arr[i][0]))) {
                    continue;
                }
                for (int j = 1; j < arr[i].Length; ++j) {
                    ans += arr[i][j];
                    if (isVowel(char.ToLower(arr[i][j]))) {
                        break;
                    }
                }
            }
            return ans;
        }

        static void Main(string[] args)
        {
            string source = "Let it be; All you need is Love; Dizzy Miss Lizzy";
            string ans = "";
            try
            {
                foreach (var el in source.Split(';', StringSplitOptions.RemoveEmptyEntries))
                {
                    ans += CreateAbbreviation(el) + '\n';
                }
            } catch(ArgumentException ex) {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(ans);
        }
    }
}
