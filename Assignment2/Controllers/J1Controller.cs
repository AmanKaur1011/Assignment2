using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        //  (2023)J1: Deliv-e--droid

        ///<summary>
        ///This  method is going to calculate the total score earned by the robot Droid by delivering 
        ///the packages while avoiding the obstacles.
        
        ///Points Criteria:
        ///10 points will be removed for every collision.
        ///50 points will be given for every pacakage delivered
        ///bonus 500 points will be given if the number of the packages delivered is greater than the collisions occurred with the obstacle
        
        ///</summary>

        ///<parm name="p">The number of packages delivered by the robot Droid</parm>
        ///<parm name="c">The number of collisions with obstacles</parm>

        ///<returns>
        ///Output the final score(integer) of the Robot Droid earned by delivering the 'p'(non- negative integer) packages and 
        /// 'c' (non- negative integer) collisions.
        
        ///</returns>

        ///<example>
        ///GET: localhost: xx/api/J1/CalculateFinalScore/5/2  -> 730
       
        ///</example>

        ///<example>
        ///GET: localhost: xx/api/J1/CalculateFinalScore/0/10 -> -100
        ///</example>
        
        ///<example>
        ///GET: localhost: xx/api/J1/CalculateFinalScore/2/6  -> 40
        ///</example>



        [HttpGet]
        [Route("api/J1/CalculateFinalScore/{p}/{c}")]

        public int CalculateFinalScore(int p, int c)
        {
            int finalScore = 0;
            // Logic for Bonus -> if the no.of pacakages delivered is more than the collisions occurred then add 500 points to the final score
           if (p > c)
            {
                finalScore = finalScore + 500;
            }
            
          // logic for calculating the scores for the pacakages delivered
                finalScore = finalScore + (50 * p);
          // logic for calculating the scores  after the collisions occurred 
            finalScore = finalScore - (10 * c);

           
          
            return finalScore;
        }
    }
}
