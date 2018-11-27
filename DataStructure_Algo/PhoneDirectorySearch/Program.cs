using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectorySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int noOfTestCases = 0;
            bool validTestCases = int.TryParse(Console.ReadLine(), out noOfTestCases);
            if(validTestCases && noOfTestCases > 0)
            {
                StringBuilder results = new StringBuilder(noOfTestCases);
                for(int i = 0;  i < noOfTestCases;  i++ )
                {
                    var no_Of_Contacts_String = Console.ReadLine();
                    var contacts_To_Search = Console.ReadLine().Trim().Split();
                    var searchKey = Console.ReadLine().Trim();
                    int no_Of_Contacts = 0;
                    bool validContacts = int.TryParse(no_Of_Contacts_String, out no_Of_Contacts);
                    if(validContacts && no_Of_Contacts > 0 && contacts_To_Search.Length == no_Of_Contacts)
                    {
                        FindMatchingContacts(contacts_To_Search, searchKey, results);
                    }                    
                 //   Console.ReadKey();

                }
                Console.Write(results);
            }
            
        }

        private static void FindMatchingContacts(string[] contacts_To_Search, string searchKey, StringBuilder results)
        {
            //throw new NotImplementedException();
           // contacts_To_Search.c
           for(int i = 0; i < searchKey.Length; i++)
            {
                var searchString = searchKey.Substring(0, i + 1);
                var searchResult = Array.FindAll(contacts_To_Search, x => x.StartsWith(searchString)).Distinct().ToArray();
                Array.Sort(searchResult);
                if (searchResult == null || searchResult.Length == 0)
                {
                    for (var y = i; y < searchKey.Length; y++)
                    {
                        results.AppendLine("0");                        
                    }
                    break;
                }
             //   var matchedResult = searchResult.
                for (var p =  0; p < searchResult.Length; p++)
                {
                    var matchedResult = searchResult[p];
                    results.Append(matchedResult, 0, matchedResult.Length);
                    
                    if(p == searchResult.Length-1)
                    {
                        results.AppendLine();
                    }
                    else
                    {
                      //  results.Append(new char[' ']);
                        results.Append("".PadRight(1));
                    }

                }
                
                
               
            }
        }

        
    }
}
