using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        // J2- Roll the Dice

        /// <summary>
        /// This method is going to determine the possible ways we can get the value(Sum)of 10 when we roll two dices having specific number of sides.
        /// </summary>
        
        /// <param name="m"> number of sides of a first dice</param>
        /// <param name="n">  number of sides of a second dice</param>
        
        /// <returns>
        ///Output the string which will show the possible number of ways a value of 10 can be returned if the 
        ///first dice has 'm' sides and second dice has 'n' sides.
        /// </returns>


        ///<example>
        ///GET: localhost: xx/api/J2/DiceGame/6/8  -> "There are 5 ways to get the sum 10."

        ///</example>

        ///<example>
        ///GET: localhost: xx/api/J2/DiceGame/12/4 ->  "There are 4 ways to get the sum 10."
        ///</example>

        ///<example>
        ///GET: localhost: xx/api/J2/DiceGame/3/3  ->  "There is 0 way to get the sum 10."
        ///</example>


        ///<example>
        ///GET: localhost: xx/api/J2/DiceGame/5/5  ->  "There  is 1 way to get the sum 10."
        ///</example>

        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string  DiceGame(int m, int n)
        {
            int valueAsTen = 0;
            int result = 0;
            string output = "";

            //Main logic
             for (int i =1; i<= m; i = i + 1)
            {
                for(int j = 1; j <= n; j = j + 1)
                {
                    result = i + j;
                    if (result == 10)
                    {
                        valueAsTen = valueAsTen + 1;
                    }

                }

            }
             // Output specification
            if (valueAsTen == 1||valueAsTen==0)
            {
                output = "There is " + valueAsTen + " way to get the sum 10.";
            }
            else {
                output = "There are " + valueAsTen + " ways to get the sum 10.";
            }
            
            

            return output; 
        }
    }
}
