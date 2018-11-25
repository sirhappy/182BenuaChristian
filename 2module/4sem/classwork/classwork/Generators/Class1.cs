using System;

namespace Generators
{
    public static class Generator
    {
        public static double Generate(this Random rnd, int mn, int mx)
        {
            return rnd.NextDouble() * (mx - mn) + mn;
        }
        public static int GenerateInt(this Random rnd, int mn, int mx)
        {
            return rnd.Next(mn, mx);
        }

        public static string GenerateString(this Random rnd, int mnLen, int mxLen)
        {
            int len = rnd.Next(mnLen, mxLen);
            string ans = "";
            for (int i = 0; i < len; ++i)
            {
                ans += (char)(rnd.Next('a', 'z'));
            }
            return ans;
        }
        public static bool Generatebool(this Random rnd, double prob = 0.5) {
            if (rnd.Next() < prob) {
                return true;
            }
            return false;
        } 
    }
}
