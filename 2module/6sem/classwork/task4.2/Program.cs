using System;

namespace task4._2
{

   
    class Program
    {
        public static string MakeOnlyOneSpace(string s)
        {
            string res = "";
            bool wasChar = false;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != ' ')
                {
                    wasChar = true;
                    res += s[i];
                }
                else
                {
                    if (wasChar)
                    {
                        res += ' ';
                    }
                    wasChar = false;
                }
            }
            return res;
        }

        public static int MoreThanKLetters(string s, int k) {
            int ans = 0;
            int curLen = 0;
            for (int i = 0; i < s.Length; ++i) {
                if (s[i] != ' ') {
                    curLen++;
                } else {
                    if (curLen > k) {
                        ans++;
                    }
                    curLen = 0;
                }
            }
            if (curLen > k) {
                ans++;
            }
            return ans;
        }

        public static int BeginWithVowel(string s) {
            int ans = 0;
            for (int i = 0; i < s.Length; ++i) {
                if (s[i] != ' ' && (i == 0 || s[i - 1] == ' ')) {
                    if (s[i] == 'a' || s[i] == 'o' || s[i] == 'u' || s[i] == 'e' || s[i] == 'i') {
                        ans++;
                    }
                }
            }
            return ans;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("enter str");
                string s = Console.ReadLine();
                //Console.WriteLine(MakeOnlyOneSpace(s));
                //Console.WriteLine(MoreThanKLetters(s, 4));
                Console.WriteLine(BeginWithVowel(s));

                Console.WriteLine("to exit pres esc");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
