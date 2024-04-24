using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.TwoPointers.Easy
{
    /*
     * 125. Valid Palindrome
     */

    public class IsPalindrome
    {
        public void Run()
        {
            Console.WriteLine(Solution("A man, a plan, a canal: Panama")); // true
            Console.WriteLine(Solution("race a car")); // false
            Console.WriteLine(Solution(" ")); // true
        }
        public bool Solution (string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return true;
            }

            var clean = s.ToLower().Where(x => char.IsLetterOrDigit(x));
            return clean.Reverse().SequenceEqual(clean);
        }
    }
}
