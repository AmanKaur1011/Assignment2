using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J3Controller : ApiController
    {

        //(2016) J3- Hidden Palindrome
        //Palindrome is a word which is same when read forwards as it is when read backwards like mom, madam, etc.

        /// <summary>
        /// The problem solution is consist of two methods:
        /// method #1(which is the main method that is used in the api get request to the localhost) is going to 
        /// give the number of charcters in the longest palindrome present in the word
        /// method #2(secondary method which is being called in method #1) is going to determine if the input word is a palindrome 

        /// This solution can also check palindromes present inside the word, even it requires to  delete few characters from the front
        /// or at the end of the word .Example of this kind of word is 'banana'.
        /// </summary>

        /// <param name="word"> The input word for which the plaindrome conditions will be checked</param>

        /// <returns>
        ///Output the integer value( of method #1) which  refers to  the number of characters (letters) in the longest palindrome present in the word.
        /// </returns>


        ///<example>
        ///GET: localhost: xx/api/J3/Checkpalindrome/mom -> 3

        ///</example>

        ///<example>
        ///GET: localhost: xx/api/J3/Checkpalindrome/banana -> 5 
        ///explanation -> It  trim the character 'b' from the begining then anana is a plaindrome

        ///<example>
        ///GET: localhost: xx/api/J3/Checkpalindrome/abracadabra  -> 3
        ///explanation ->there are two longest paloindromes here 'aca' and 'ada' both have 3 characters in it 

        ///<example>
        ///GET: localhost: xx/api/J3/Checkpalindrome/abba  ->  4
        ///</example>

        [HttpGet]
        [Route("api/J3/Checkpalindrome/{word}")]
        public int Checkpalindrome(string word)
        {
            int numberOfChar = 0;     //number of characters in a plaindrome
            string a;
            string b="";

            //if the whole word ia a palindrome
            if ((palindrome(word)) == true)
            {
                numberOfChar = word.Length;

            }
           // if the plaindrome is present inside the word
            else {
                        for (int i = 1; i < word.Length; i++)
                        {
                            a = word.Remove(0, i);
                               b = a;
                             for (int j = 1; j < a.Length; j++)
                                {
                                    if ((palindrome(b)) == true)
                                    {
                                        if (numberOfChar < b.Length)
                                        {
                                     
                                            numberOfChar = b.Length;
                                        }
                                        
                                        break;
                                    };
                                        b = a.Remove(a.Length - j);

                              }// end of inner for loop
                           

                        }// end of outer for loop
            }// end of else statement


            return numberOfChar;
        }// end of Checkpalindrome 

 // separate method#2 which helps in checking if the word is a plaindrome or not

        private bool palindrome(string w)
        {
           // Below logic will compare the original string and it's reverted value and
           // based on that will tell if it's a plaindrome 
          //if a word is a palindrome it's original string  value and reverted value are always same

            char[] wordArray = w.ToCharArray();
            char[] revWordArray = w.ToCharArray();
            Array.Reverse(revWordArray);
            string original = new string(wordArray);
            string reverted = new string(revWordArray);
            if (original == reverted)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
