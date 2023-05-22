using System;
using System.Collections.Generic;

namespace Rim_to_arab
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(RomanToInt(s.ToUpper()));
            Console.ReadKey();
        }
        static public int RomanToInt(string s)
        {
            int sum = 0;
            Dictionary<char, int> romanianToInt = new Dictionary<char, int>()
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000
            };
            if (s.Length == 1) return romanianToInt[s[0]];
            for (int i = 1; i < s.Length; i++)
            {
                if (romanianToInt.ContainsKey(s[i - 1]) && romanianToInt.ContainsKey(s[i]))
                {
                    if (romanianToInt[s[i - 1]] < romanianToInt[s[i]])
                    {
                        sum += romanianToInt[s[i]] - romanianToInt[s[i - 1]];
                        i += 1;
                        if (i == s.Length - 1) { sum += romanianToInt[s[i]]; }

                    }
                    else if (romanianToInt[s[i - 1]] >= romanianToInt[s[i]] && i != s.Length - 1)
                    {
                        sum += romanianToInt[s[i - 1]];
                    }
                    else if (romanianToInt[s[i - 1]] >= romanianToInt[s[i]] && i == s.Length - 1)
                    {
                        sum += romanianToInt[s[i]] + romanianToInt[s[i - 1]];
                    }
                }
            }
            return sum;
        }
    }
}
