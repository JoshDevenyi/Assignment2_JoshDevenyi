using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_n01486790.Controllers
{
    public class J3Controller : ApiController
    {   /// J3 2002 - The Students' Council Breakfast
        /// <summary>
        /// A program that calculates the total combinations possible to reach a fundraising goal based on the prices of the four different ticket types. 
        /// </summary>
        /// <param name="PinkCost">The cost of a pink ticket</param>
        /// <param name="GreenCost">The cost of a green ticket</param>
        /// <param name="RedCost">The cost of a red ticket</param>
        /// <param name="OrangeCost">The cost of a orange ticket</param>
        /// <param name="Goal">The total funraising goal</param>
        /// <returns> One possible combination of tickets, the total possible combinations, and the minimum amount of tickets that would have to be sold to reach the goal.</returns>
        /// <example>
        /// GET : /api/j3/Breakfast/1/2/3/4/3 ->
        /// One Possible Combination: # of PINK is 3, # of GREEN is 0, # of RED is 0, # of ORANGE is 0
        /// Total Combinations is 3.
        /// Minimum number of tickets to print is 1.
        /// </example>
        [HttpGet]
        [Route("api/j3/breakfast/{PinkCost}/{GreenCost}/{RedCost}/{OrangeCost}/{Goal}")]
        public IEnumerable<string> Breakfast(int PinkCost, int GreenCost, int RedCost, int OrangeCost, int Goal)
        {
           
            //Calculates the maximum limit of each ticket type based on the goal.
            int PinkLimit = Goal / PinkCost;
            int GreenLimit = Goal / GreenCost;
            int RedLimit = Goal / RedCost;
            int OrangeLimit = Goal / OrangeCost;

            //Sets up a variable for each ticket outside of the main loop structure that will hold the total of each needed for a successful combination.
            int PinkTotal = 0;
            int GreenTotal = 0;
            int RedTotal = 0;
            int OrangeTotal = 0;

            //Variables that will keep track of the total amount of successful combinations and the successful combination with the smallest number of tickets.
            int TotalCombinations = 0;
            int MinTickets = 0;


            //Loop to increase the number of Pink Tickets
            for (int PinkCounter = 0; PinkCounter <= PinkLimit; PinkCounter++) {

                //Loop to increase the number of Green Tickets
                for (int GreenCounter = 0; GreenCounter <= GreenLimit; GreenCounter++)
                {
                    //Loop to increase the number of Red Tickets
                    for (int RedCounter = 0; RedCounter <= RedLimit; RedCounter++)
                    {
                        //Loop to increase the number of Orange Tickets
                        for (int OrangeCounter = 0; OrangeCounter <= OrangeLimit; OrangeCounter++)
                        {
                            //Calculating the total gross of each ticket type.
                            int PinkGross = PinkCost * PinkCounter;
                            int GreenGross = GreenCost * GreenCounter;
                            int RedGross = RedCost * RedCounter;
                            int OrangeGross = OrangeCost * OrangeCounter;

                            //Calculating the overall gross and total number of tickets for the current combination.
                            int TotalGross = PinkGross + GreenGross + RedGross + OrangeGross;
                            int TotalTickets = PinkCounter + GreenCounter + RedCounter + OrangeCounter;

                            //Checks to see if the Goal was reached
                            if (TotalGross == Goal)
                            {
                                //Sets the amount of each colour need for the current successful combination to a variable outside of the loops.
                                PinkTotal = PinkCounter;
                                GreenTotal = GreenCounter;
                                RedTotal = RedCounter;
                                OrangeTotal = OrangeCounter;

                                //Tallys up the amount of successful combinations discovered                                
                                TotalCombinations = TotalCombinations + 1;


                                //Establishes the initial value of MinTickets to be the first combination reached.
                                if(TotalCombinations == 1)
                                {
                                    MinTickets = TotalTickets;
                                }   

                                //Overwrites MinTickets whenever a new combination has a smaller ticket count.
                                if (TotalTickets < MinTickets)
                                {
                                    MinTickets = TotalTickets;
                                }

                            }
                        }
                    }
                }           
            }

            return new string[]
            {
                //For HTTP - I only return one combination (the final option the loops reach). Within the HTTP context I wasn't sure how to keep returning each successful combination within my loops. 
                "One Possible Combination: # of PINK is " + PinkTotal + ", # of GREEN is " + GreenTotal + ", # of RED is " + RedTotal + ", # of ORANGE is " + OrangeTotal,
                "Total Combinations is " + TotalCombinations + ".",
                "Minimum number of tickets to print is " + MinTickets + "."
            };

        }

    }

}

