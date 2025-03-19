using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.TwoPointers.Easy;

/*
 * 125. Valid Palindrome
 * A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
   Given a string s, return true if it is a palindrome, or false otherwise.
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
