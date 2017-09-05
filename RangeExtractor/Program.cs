using System;
using System.Collections.Generic;

/*
Author: Jason Bergener

This code was written in response to a SoloLearn daily challenge.
The instructions were:
Write a program that takes a list of integers in increasing order
and returns a correctly formatted string in the range format.

Example:
Input: [-6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20]
Output "-6,-3-1,3-5,7-11,14,15,17-20"

Example 2:
Input: [-5,-4,0,5,6,7,9,10]
output: "-5,-4,0,5-7,9,10"

Example 3:
Input: [1,2,3,5,6,8,9,10,11]
Output: "1-3,5,6,8-11"

Note: a range spans at least 3 numbers. e.g. 1,2,3: 1-3 and 5,6: 5,6 and 8,9,10,11: 8-11
*/

namespace RangeExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int> { 1, 2, 3, 6, 8, 10, 11, 12, 15, 16, 18 };
            Console.WriteLine(RangeExtract(test));
        }
        static string RangeExtract(List<int> l)
        {
            string s = l[0].ToString();
            int lastadd = l[0];
            int last = l[0];
            bool range = false;
            for (int i = 1; i < l.Count; i++)
            {
                if (range)
                {
                    if (i == (l.Count - 1))
                    {
                        if (l[i] == (last + 1))
                        {
                            s += $"-{l[i].ToString()}";
                        }
                        else
                        {
                            s += $"-{last.ToString()}, {l[i].ToString()}";
                        }
                    }
                    else if (l[i] == (last + 1))
                    {
                        last = l[i];
                    }
                    else
                    {
                        s += $"-{last.ToString()}, {l[i].ToString()}";
                        lastadd = l[i];
                        last = l[i];
                        range = false;
                    }
                }
                else if (l[i] == (last + 1))
                {
                    if (i == (l.Count - 1))
                    {
                        s += $"-{l[i].ToString()}";
                    }

                    last = l[i];
                    range = true;
                }
                else if (l[i] > (last + 1))
                {
                    s += $", {l[i].ToString()}";
                    lastadd = l[i];
                    last = l[i];
                }
                else
                {
                    return "Something went wrong.";
                }
            }
            return s;
        }
    }
}