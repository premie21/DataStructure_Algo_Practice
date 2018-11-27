using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSunArraysWithSumLessThanK
{
    // This progam having the concept of sliding window
    class Program
    {
        public static void Main(string[] args)
        {
            //  Console.WriteLine(args.Length);
            string firstLine = Console.ReadLine();
            int numberOfTestCases = -1;
            string[] outputArray = null;
            if (int.TryParse(firstLine, out numberOfTestCases))
            {
                if (numberOfTestCases > 0)
                {
                    outputArray = new string[numberOfTestCases];
                    for (int i = 0; i < numberOfTestCases; i++)
                    {
                        string testCaseFirstLine = Console.ReadLine().Trim();
                        var testCaseFirstLineValues = testCaseFirstLine.Split(' ');
                        int numberOfElementsInArray = -1;
                        long maxSum = -1;

                        if (int.TryParse(testCaseFirstLineValues[0], out numberOfElementsInArray) && long.TryParse(testCaseFirstLineValues[1], out maxSum))
                        {
                            var arrayString = Console.ReadLine().Split(' ');
                            long[] arrayInt = new long[numberOfElementsInArray];
                            //// arrayString.Cast<int>();
                            //Array.ConvertAll<string[], int[]>(arrayString, arrayInt);
                            //if (arrayString.Length == numberOfElementsInArray)
                            //{
                            for (int k = 0; k < numberOfElementsInArray; k++)
                            {
                                arrayInt[k] = long.Parse(arrayString[k]);
                            }
                            // }

                            outputArray[i] = PrintCountOfSubArraysWithSumLessThanK2(arrayInt, maxSum);
                        }
                    }
                }
                foreach (var o in outputArray)
                {
                    Console.WriteLine(o);
                }
            }
               Console.ReadKey();
        }

        private static string PrintCountOfSubArraysWithSumLessThanK(int[] arrayInt, int maxSum)
        {
            // This will take O(n2) time 
            int count = 0;
            for(int i = 0; i < arrayInt.Length; i++)
            {
                if(arrayInt[i] < maxSum)
                {
                    if (i == arrayInt.Length - 1)
                    {
                       // if(maxSum % arrayInt[i] == 0) 
                        ++count;
                    }
                    else
                    {
                       // int localSum = 0;
                        int localSum = 1;
                        int j = i;
                        while (localSum < maxSum)
                        {

                            if (j >= arrayInt.Length)
                            {
                                //  ++count;
                                break;
                            }
                            //  localSum = localSum + arrayInt[j];
                            localSum = localSum * arrayInt[j];
                            if (localSum < maxSum)
                                ++count;
                            ++j;
                        }
                    }
                }
            }
            //  Console.WriteLine(count);
            return count.ToString();
        }

        private static string PrintCountOfSubArraysWithSumLessThanK2(long[] arrayInt, long maxSum)
        {
            //// This will take O(n) time 
            int count = 0, index = 0;
            long localProduct = 1;
            for (int i = 0; i < arrayInt.Length; i++)
            {
                localProduct = localProduct * arrayInt[i];
                if (localProduct < maxSum)
                {
                    count = count + 1 + i - index;
                }
                else
                {
                    while (localProduct > maxSum)
                    {
                        localProduct = localProduct / arrayInt[index];
                        index++;
                    }
                    if (localProduct < maxSum)
                    {
                        count = count + i - (index - 1);
                    }
                }

            }
            //  Console.WriteLine(count);
            return count.ToString();
        }
    }
}
