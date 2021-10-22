using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_n01486790.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// A program that compares two die and returns how many possibilites there form them to roll a 10
        /// </summary>
        /// <param name="m">A positive integer representing the number of sides of the first die</param>
        /// <param name="n">A positive integer representing the number of sides of the second die</param>
        /// <returns>A message explaining the amount of possible ways the two die could roll a 10</returns>
        /// <example>
        ///  GET : /api/j1/DiceGame/6/8 -> There are 5 total ways to get the sum of 10.
        /// </example>
        /// <example>
        ///  GET : /api/j1/DiceGame/6/-8 -> Please input two positive integers.
        /// </example>
        [HttpGet]
        [Route("api/j2/DiceGame/{m}/{n}")]
        public string DiceGame(int m, int n)
        {

            var TotalTens = 0;
            var message = "";

            //Checks that both values are positive integers
            if (m <= 0 || n <= 0)
            {

                message = message + "Please input two positive integers.";

            }

            //Compares die combinations, keeping track of every 10 found.
            else
            {

                for (int i = 1; i <= m; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {

                        if (i + j == 10)
                        {
                            TotalTens = TotalTens + 1;
                        }


                    }
                }

                message = message + "There are " + TotalTens.ToString() + " total ways to get the sum of 10.";

            }

            return message;

        }

    }


}
