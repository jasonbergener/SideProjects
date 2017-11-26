using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideProjects
{
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
    public class RangeExtractor
    {
        public static string RangeExtract(List<int> input)
        {
            string result = input[0].ToString(); //creates the result string and adds the first number
            int lastadd = input[0]; //identifies the last number added to the result string
            int last = input[0]; //identifies the last number worked with
            bool range = false; //flag to identifiy if we are currently in a range or not
            bool possible = false; //second flag to account for a 2-number range
            for (int i = 1; i < input.Count; i++) //we start at the second element because we added the first
            {
                if (range) //if we are currently inside a range
                {
                    if (i == (input.Count - 1)) //this makes sure we add the last element if it is part of a range
                    {
                        if (input[i] == (last + 1)) //finishes the range if the last element is part of it
                        {
                            result += $"-{input[i].ToString()}";
                        }
                        else //closes the range and adds the last element if it was outside the range
                        {
                            result += $"-{last.ToString()}, {input[i].ToString()}";
                        }
                    }
                    else if (input[i] == (last + 1)) //if the number is one higher than the last, we are still in the range
                    {
                        last = input[i];
                    }
                    else //this happens if the current number is more than one higher than the last
                    {
                        result += $"-{last.ToString()}, {input[i].ToString()}"; //closes the range and adds the current element
                        lastadd = input[i];
                        last = input[i];
                        range = false; //we just closed a range and the next iteration will check if a new one starts
                        possible = false;
                    }
                }
                else if (possible) //this starts with 2 in a row and checks for a third
                {
                    if (input[i] == (last + 1)) //this marks 3 in a row and validates a range
                    {
                        if (i == (input.Count - 1)) //catches the last element
                        {
                            result += $"-{input[i].ToString()}";
                        }

                        //if it wasn't the last element, nothing is added to the string yet
                        last = input[i];
                        range = true; //sets the range flag and we start working in the above loop
                    }
                    else //was only 2 in a row so no range
                    {
                        result += $", {input[i-1].ToString()}, {input[i].ToString()}";
                        lastadd = input[i];
                        last = input[i];
                        possible = false;
                    }
                }
                else if (input[i] == (last + 1)) //this would mark 2 in a row
                {
                    if (i == (input.Count - 1)) //catches the last element
                    {
                        result += $", {input[i].ToString()}";
                    }

                    last = input[i];
                    possible = true; //sets the possible flag (2 in a row)
                }
                else if (input[i] > (last + 1)) //definitely not a range
                {
                    result += $", {input[i].ToString()}";
                    lastadd = input[i];
                    last = input[i];
                }
                else
                {
                    return "Something went wrong.";
                }
            }
            return result;
        }
    }
}
