﻿using leetcode_solutions_csharp.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_solutions_csharp.Array_HashTable.Medium;

public class Encode_DecodeStrings
{
    /*
     * 271. Encode and Decode Strings - https://neetcode.io/problems/string-encode-and-decode
     */

    public void Run()
    {
        var encoded1 = Encode(new List<string> { "hello", "world", "C#", "123#456" });
        List<string> decoded1 = Decode(encoded1);

        Console.WriteLine(encoded1);
        Console.WriteLine(ToStringHelper.NestedListToString(decoded1));

        var encoded2 = Encode(new List<string> { "we", "say", ":", "yes" });
        List<string> decoded2 = Decode(encoded2);
        Console.WriteLine(encoded2);
        Console.WriteLine(ToStringHelper.NestedListToString(decoded2));
    }

    public string Encode(IList<string> strs)
    {
        string res = "";
        foreach (string s in strs)
        {
            res += s.Length + "#" + s;
        }
        return res;
    }

    public List<string> Decode(string s)
    {
        List<string> res = new List<string>();
        int i = 0;
        while (i < s.Length)
        {
            int j = i;
            while (s[j] != '#')
            {
                j++;
            }
            int length = int.Parse(s.Substring(i, j - i));
            i = j + 1;
            j = i + length;
            res.Add(s.Substring(i, length));
            i = j;
        }
        return res;
    }
}
