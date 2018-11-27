using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closest_Palindrome
{
  public class Program
    {
        public static void Main(string[] args)
        {
            var no_of_testcases = Console.ReadLine();
            int no_of_testcases_int;
            
            if (int.TryParse(no_of_testcases, out no_of_testcases_int))
            {
                string[] outputArray = new string[no_of_testcases_int];
                for(int i = 0; i < no_of_testcases_int; i++)
                {
                    var pallindromeString = Console.ReadLine();
                    long pallindromeNumber;
                    if (long.TryParse(pallindromeString, out pallindromeNumber))
                    {
                        pallindromeString = pallindromeNumber.ToString();
                        if (pallindromeString.Length == 1)
                        {
                            outputArray[i] = pallindromeString;
                        }
                       else if(pallindromeString.Length % 2 == 0)
                        {
                            var halfLength = pallindromeString.Length / 2;
                            var lefthalf = pallindromeString.Substring(0, halfLength);
                            var righthalf = pallindromeString.Substring(halfLength);
                            var midElement = "";
                            outputArray[i] = SearchPallindrome(lefthalf, midElement, righthalf);
                        }
                        else
                        {
                            var halfLength = (pallindromeString.Length -1 )/ 2;
                            var lefthalf = pallindromeString.Substring(0, halfLength);
                            var righthalf = pallindromeString.Substring(halfLength +1);
                            var midElement = pallindromeString.Substring(halfLength, 1);
                            outputArray[i] = SearchPallindrome(lefthalf, midElement, righthalf);
                        }

                    }
                }
                foreach(var i in outputArray)
                {
                    Console.WriteLine(i);
                }
                Console.ReadLine();
            }
        }

        private static string SearchPallindrome(string lefthalf, string midElement, string righthalf)
        {
            // throw new NotImplementedException();
            string straightPallindrome = "", lesserPallindrome = "", greaterPallindrome = "", givenNum = lefthalf + midElement + righthalf;
            straightPallindrome = lefthalf + midElement + new string( lefthalf.Reverse().ToArray());
          //  string resultantPaliindrome = "";
            //   if(SearchPallindrome)
            if (long.Parse(straightPallindrome) - long.Parse(givenNum) > 0)
            {
                greaterPallindrome = straightPallindrome;

                var temp = (long.Parse(lefthalf + midElement) - 1).ToString();
                var pivotElement = midElement.Length != 0 ? midElement : lefthalf.Substring(lefthalf.Length - 1);
                if (pivotElement == "0")
                {
                    if (midElement != "")
                    {
                        if (temp.Length < lefthalf.Length + midElement.Length)
                        {
                            // lefthalf = temp + "9";
                            lefthalf = temp;
                        }
                        else
                        {
                            // lefthalf = temp;
                            lefthalf = temp.Substring(0, temp.Length - 1);
                        }
                    }
                    else
                    {
                        if (temp.Length < lefthalf.Length + midElement.Length)
                        {
                            lefthalf = temp + "9";
                          //  lefthalf = temp;
                        }
                        else
                        {
                               lefthalf = temp;
                            // lefthalf = temp.Substring(0, temp.Length - 1);
                        }
                    }


                }
                if (temp.Length == 1 || midElement == "")
                {
                    lefthalf = temp;
                }
                lesserPallindrome = temp + new string( lefthalf.Reverse().ToArray());

            }
            else if (long.Parse(straightPallindrome) - long.Parse(givenNum) < 0)
            {
                lesserPallindrome = straightPallindrome;              

                var temp = (long.Parse(lefthalf + midElement) + 1).ToString();
                var pivotElement = midElement.Length != 0 ? midElement : lefthalf.Substring(lefthalf.Length - 1);
                if (pivotElement == "9")
                {
                    if (midElement != "")
                    {
                        if (temp.Length > lefthalf.Length + midElement.Length)
                        {                            
                            lefthalf = temp.Substring(0, temp.Length - 2);
                        }
                        else
                        {
                            lefthalf = temp.Substring(0, temp.Length - 1);
                        }

                    }
                    else
                    {
                        if (temp.Length > lefthalf.Length + midElement.Length)
                        {
                            lefthalf = temp.Substring(0, temp.Length - 1);
                        }
                        else
                        {
                            lefthalf = temp;
                        }                       
                    }
                }
                if(temp.Length == 1 || midElement == "")
                {
                    lefthalf = temp;
                }
                greaterPallindrome = temp + new string( lefthalf.Reverse().ToArray());               

            }
            else
            {
                return givenNum;
            }

            if((long.Parse(givenNum) - long.Parse(lesserPallindrome)) <= (long.Parse(greaterPallindrome) - long.Parse(givenNum)))
            {
                return lesserPallindrome;
            }
            else
            {
                return greaterPallindrome;
            }
        }
    }
}
